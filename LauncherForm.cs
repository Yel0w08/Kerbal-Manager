using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace KSP_DL
{
    public partial class LauncherForm : Form
    {
        private const string CkanDownloadUrl = "https://github.com/KSP-CKAN/CKAN/releases/latest/download/CKAN.exe";
        private static readonly HttpClient HttpClient = new();
        private static readonly string[] KspArchiveParts =
        {
            "Kerbal Space Program.7z.001",
            "Kerbal Space Program.7z.002",
            "Kerbal Space Program.7z.003",
            "Kerbal Space Program.7z.004",
            "Kerbal Space Program.7z.005",
            "Kerbal Space Program.exe",
        };

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
                DownloadKspButton_Click(sender, e);
                return;
            }

            LaunchExecutable(kspPath);
        }

        private async void CleanArchivesButton_Click(object sender, EventArgs e)
        {
            if (!HasArchiveDownloads())
            {
                MessageBox.Show(
                    "No archive download files were found in this launcher folder.",
                    "Nothing To Clean",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var confirm = MessageBox.Show(
                "Remove downloaded archive files now?\nYour extracted or installed KSP files will be kept.",
                "Clean Download Files",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                SetBusyState(true, "Cleaning archive files...");
                await CleanupArchiveDownloadsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cleanup failed:\n{ex.Message}",
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
            launchKspButton.Enabled = true;
            launchKspButton.Text = canLaunchKsp ? "Launch KSP" : "Install KSP";
            launchKspButton.IconChar = canLaunchKsp ? IconChar.Play : IconChar.Download;
            launchKspButton.IconColor = Color.White;
            cleanArchivesButton.Enabled = HasArchiveDownloads();
            FooterLabel.Text = canLaunchKsp
                ? $"Launch target: {kspExecutablePath}"
                : downloadsPrepared
                    ? "KSP package files are here. Finish extraction, then launch from this panel."
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

        private bool HasArchiveDownloads()
        {
            return KspArchiveParts.Any(fileName => File.Exists(Path.Combine(launcherDirectory, fileName)));
        }

        private async Task CleanupArchiveDownloadsAsync()
        {
            await Task.Run(() =>
            {
                foreach (var fileName in KspArchiveParts)
                {
                    var path = Path.Combine(launcherDirectory, fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
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
            cleanArchivesButton.Enabled = !isBusy && HasArchiveDownloads();

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
