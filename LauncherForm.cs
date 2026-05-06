using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace KSP_DL;

public partial class LauncherForm : Form
{
    private static readonly HttpClient HttpClient = new();
    private readonly string launcherDirectory = LauncherEnvironment.LauncherDirectory;
    private readonly string localCkanPath = Path.Combine(LauncherEnvironment.LauncherDirectory, "CKAN.exe");

    private static readonly string[] CkanCandidates =
    [
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
    ];

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
        using var downloader = new DownloadForm();
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

        if (result == DialogResult.Yes)
        {
            await DownloadCkanAsync();
        }
    }

    private void OpenDownloadsButton_Click(object sender, EventArgs e)
    {
        Directory.CreateDirectory(launcherDirectory);
        Process.Start(new ProcessStartInfo { FileName = launcherDirectory, UseShellExecute = true });
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
        UpdateInstallStatus();
    }

    private void LaunchKspButton_Click(object sender, EventArgs e)
    {
        var kspPath = LauncherEnvironment.FindKspExecutable(launcherDirectory);
        if (string.IsNullOrWhiteSpace(kspPath))
        {
            DownloadKspButton_Click(sender, e);
            return;
        }

        LaunchExecutable(kspPath);
    }

    private void OpenGameFolderButton_Click(object sender, EventArgs e)
    {
        var kspPath = LauncherEnvironment.FindKspExecutable(launcherDirectory);
        if (string.IsNullOrWhiteSpace(kspPath))
        {
            MessageBox.Show("No KSP installation folder was found yet.", "Game Folder Unavailable",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var gameDirectory = Path.GetDirectoryName(kspPath);
        if (!string.IsNullOrWhiteSpace(gameDirectory))
        {
            Process.Start(new ProcessStartInfo { FileName = gameDirectory, UseShellExecute = true });
        }
    }

    private async void CleanArchivesButton_Click(object sender, EventArgs e)
    {
        if (!LauncherEnvironment.HasArchiveDownloads(launcherDirectory))
        {
            MessageBox.Show("No archive download files were found in this launcher folder.", "Nothing To Clean",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show(
            "Remove downloaded archive files now?\nYour extracted or installed KSP files will be kept.",
            "Clean Download Files",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm == DialogResult.Yes)
        {
            try
            {
                SetBusyState(true, "Cleaning archive files...");
                await Task.Run(() =>
                {
                    foreach (var path in LauncherEnvironment.GetArchiveArtifactPaths(launcherDirectory))
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cleanup failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetBusyState(false);
            }
        }
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void UpdateInstallStatus()
    {
        var ckanInstalled = CkanCandidates.Any(File.Exists);
        var kspExecutablePath = LauncherEnvironment.FindKspExecutable(launcherDirectory);
        var downloadsPrepared = HasKspDownloads();
        var canLaunchKsp = !string.IsNullOrWhiteSpace(kspExecutablePath);
        var hasKey = LauncherEnvironment.TryReadDecryptionKey(out _, out var keySourcePath);

        LibraryStatusLabel.Text = "Community launcher for Kerbal Space Program downloads and mods.";
        InstallStatusValueLabel.Text = canLaunchKsp
            ? "KSP ready to launch"
            : downloadsPrepared ? "KSP files detected" : "Ready to download";
        ModsStatusValueLabel.Text = ckanInstalled ? "CKAN ready" : "CKAN missing";
        LaunchStatusValueLabel.Text = canLaunchKsp ? "Launch available" : "Install not detected";
        launchKspButton.Enabled = true;
        launchKspButton.Text = canLaunchKsp ? "Launch KSP" : "Install KSP";
        launchHintLabel.Text = canLaunchKsp
            ? "Your game files are ready. Launch directly or open the install folder."
            : downloadsPrepared
                ? "KSP packages are present. Finish extraction to unlock direct play."
                : "Start here to download KSP into this launcher folder.";
        openGameFolderButton.Enabled = canLaunchKsp;
        cleanArchivesButton.Enabled = LauncherEnvironment.HasArchiveDownloads(launcherDirectory);
        KeyStatusValueLabel.Text = hasKey ? "Key ready" : "Key missing";
        KeySourceLabel.Text = hasKey
            ? $"Source: {Path.GetFileName(keySourcePath)}"
            : "Place `uncrypt_key` next to the launcher.";
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
            await DownloadFileAsync(KspConstants.CkanDownloadUrl, localCkanPath);
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
            MessageBox.Show($"CKAN download failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetBusyState(false);
        }
    }

    private static async Task DownloadFileAsync(string sourceUrl, string destinationPath)
    {
        using var response = await HttpClient.GetAsync(sourceUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        await using var input = await response.Content.ReadAsStreamAsync();
        await using var output = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await input.CopyToAsync(output);
    }

    private static bool HasKspDownloads()
    {
        var kspFiles = new[]
        {
            "Kerbal Space Program.exe",
            "Kerbal Space Program.7z.001",
            "KSP-Extracted",
        };

        return kspFiles.Any(name =>
        {
            var path = Path.Combine(LauncherEnvironment.LauncherDirectory, name);
            return File.Exists(path) || Directory.Exists(path);
        });
    }

    private static void LaunchExecutable(string path)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(path) ?? LauncherEnvironment.LauncherDirectory,
        });
    }

    private void SetBusyState(bool isBusy, string? title = null)
    {
        downloadKspButton.Enabled = !isBusy;
        openCkanButton.Enabled = !isBusy;
        openDownloadsButton.Enabled = !isBusy;
        refreshButton.Enabled = !isBusy;
        exitButton.Enabled = !isBusy;
        cleanArchivesButton.Enabled = !isBusy && LauncherEnvironment.HasArchiveDownloads(launcherDirectory);
        openGameFolderButton.Enabled = !isBusy && !string.IsNullOrWhiteSpace(LauncherEnvironment.FindKspExecutable(launcherDirectory));

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
