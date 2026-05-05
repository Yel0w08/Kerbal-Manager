using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSP_DL
{
    public partial class LauncherForm : Form
    {
        private const string CkanDownloadUrl = "https://github.com/KSP-CKAN/CKAN/releases/latest/download/CKAN.exe";
        private static readonly HttpClient HttpClient = new();

        private static readonly string[] CkanCandidates =
        {
            Path.Combine(AppContext.BaseDirectory, "CKAN.exe"),
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "CKAN",
                "CKAN.exe"
            ),
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                "CKAN",
                "CKAN.exe"
            ),
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                "CKAN",
                "CKAN.exe"
            ),
        };

        private readonly string launcherDirectory = AppContext.BaseDirectory;
        private readonly string localCkanPath = Path.Combine(AppContext.BaseDirectory, "CKAN.exe");

        public LauncherForm()
        {
            InitializeComponent();
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            UpdateInstallStatus();
        }

        private void DownloadKspButton_Click(object sender, EventArgs e)
        {
            using var downloader = new UncryptKey();
            downloader.ShowDialog(this);
            UpdateInstallStatus();
        }

        private async void OpenCkanButton_Click(object sender, EventArgs e)
        {
            var ckanPath = CkanCandidates.FirstOrDefault(File.Exists);
            if (!string.IsNullOrWhiteSpace(ckanPath))
            {
                LaunchExecutable(ckanPath);
                return;
            }

            var result = MessageBox.Show(
                "CKAN was not found in this launcher folder.\nWould you like to download it here now?",
                "Download CKAN",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            await DownloadCkanAsync();
        }

        private void OpenDownloadsButton_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(launcherDirectory);
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = launcherDirectory,
                    UseShellExecute = true,
                }
            );
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UpdateInstallStatus();
        }

        private void LaunchKspButton_Click(object sender, EventArgs e)
        {
            var kspPath = FindKspExecutable();
            if (string.IsNullOrWhiteSpace(kspPath))
            {
                MessageBox.Show(
                    "KSP_x64.exe was not found in the launcher folder yet.\nDownload or extract KSP first.",
                    "KSP Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            LaunchExecutable(kspPath);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateInstallStatus()
        {
            var ckanInstalled = CkanCandidates.Any(File.Exists);
            var kspExecutablePath = FindKspExecutable();
            var downloadsPrepared = HasKspDownloads();
            var canLaunchKsp = !string.IsNullOrWhiteSpace(kspExecutablePath);

            LibraryStatusLabel.Text = "Community launcher for Kerbal Space Program downloads and mods.";
            InstallStatusValueLabel.Text = canLaunchKsp
                ? "KSP ready to launch"
                : downloadsPrepared ? "KSP files detected" : "Ready to download";
            ModsStatusValueLabel.Text = ckanInstalled ? "CKAN ready" : "CKAN missing";
            LaunchStatusValueLabel.Text = canLaunchKsp ? "Launch available" : "Install not detected";
            launchKspButton.Enabled = canLaunchKsp;
            FooterLabel.Text = canLaunchKsp
                ? $"Launch target: {kspExecutablePath}"
                : ckanInstalled
                    ? "Mods are ready to launch through CKAN."
                    : "Click Open CKAN to download it into this launcher folder.";
        }

        private async Task DownloadCkanAsync()
        {
            try
            {
                SetBusyState(true, "Downloading CKAN...");
                Directory.CreateDirectory(launcherDirectory);
                await DownloadFileAsync(CkanDownloadUrl, localCkanPath);
                UpdateInstallStatus();

                var launchNow = MessageBox.Show(
                    $"CKAN was downloaded to:\n{localCkanPath}\n\nOpen it now?",
                    "CKAN Ready",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (launchNow == DialogResult.Yes)
                {
                    LaunchExecutable(localCkanPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"CKAN download failed:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                SetBusyState(false);
            }
        }

        private async Task DownloadFileAsync(string sourceUrl, string destinationPath)
        {
            using var response = await HttpClient.GetAsync(sourceUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            await using var input = await response.Content.ReadAsStreamAsync();
            await using var output = new FileStream(
                destinationPath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None
            );

            await input.CopyToAsync(output);
        }

        private bool HasKspDownloads()
        {
            var kspFiles = new[]
            {
                "Kerbal Space Program.exe",
                "Kerbal Space Program.7z.001",
                "KSP-Extracted",
            };

            return kspFiles.Any(name =>
            {
                var path = Path.Combine(launcherDirectory, name);
                return File.Exists(path) || Directory.Exists(path);
            });
        }

        private string? FindKspExecutable()
        {
            var directCandidates = new[]
            {
                Path.Combine(launcherDirectory, "KSP_x64.exe"),
                Path.Combine(launcherDirectory, "KSP-Extracted", "KSP_x64.exe"),
                Path.Combine(launcherDirectory, "KSP-Extracted", "Kerbal Space Program", "KSP_x64.exe"),
            };

            foreach (var candidate in directCandidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            if (!Directory.Exists(launcherDirectory))
            {
                return null;
            }

            return Directory
                .EnumerateFiles(launcherDirectory, "KSP_x64.exe", SearchOption.AllDirectories)
                .FirstOrDefault();
        }

        private void LaunchExecutable(string path)
        {
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetDirectoryName(path) ?? launcherDirectory,
                }
            );
        }

        private void SetBusyState(bool isBusy, string? title = null)
        {
            downloadKspButton.Enabled = !isBusy;
            openCkanButton.Enabled = !isBusy;
            openDownloadsButton.Enabled = !isBusy;
            refreshButton.Enabled = !isBusy;
            exitButton.Enabled = !isBusy;

            if (title is not null)
            {
                FooterLabel.Text = title;
            }
            else
            {
                UpdateInstallStatus();
            }
        }
    }
}
