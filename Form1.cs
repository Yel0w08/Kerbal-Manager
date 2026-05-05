using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace KSP_DL
{
    public partial class UncryptKey : Form
    {
        private const string SupportedVersion = "Kerbal Space Program 1.12.5.3190 (latest)";
        private const string RepositoryOwner = "Yel0w08";
        private const string RepositoryName = "storage.archive.data";
        private const string RepositoryCommit = "6a4e68875160458baf09aa36fe9ac79fa07ada91";
        private const string RepositoryVersionPath = "Games/Kerbal Space Program/Kerbal Space Program 1.12.5.3190";

        private static readonly string[] ArchiveParts =
        {
            "Kerbal Space Program.7z.001",
            "Kerbal Space Program.7z.002",
            "Kerbal Space Program.7z.003",
            "Kerbal Space Program.7z.004",
            "Kerbal Space Program.7z.005",
        };

        private static readonly HttpClient HttpClient = new();

        private readonly string launcherDirectory = LauncherEnvironment.LauncherDirectory;

        private readonly Dictionary<string, DownloadPreset> downloadPresets;
        private CancellationTokenSource? downloadCancellationTokenSource;
        private bool isDownloadInProgress;
        private bool isClosingAfterCleanup;
        private string autoDetectedKeyPath = string.Empty;

        public UncryptKey()
        {
            InitializeComponent();

            downloadPresets = new Dictionary<string, DownloadPreset>(StringComparer.OrdinalIgnoreCase)
            {
                [".7z"] = new DownloadPreset("7zip_Archive", ArchiveParts),
                ["SFX"] = new DownloadPreset(
                    "Self_Extracting",
                    ArchiveParts.Concat(new[] { "Kerbal Space Program.exe" }).ToArray()
                ),
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = 1000;
            ProgressBar.Value = 0;
            KSP_Version.SelectedIndex = 0;
            TypeOfFile.SelectedIndex = 0;
            FormClosing += UncryptKey_FormClosing;
            UpdateStartupWarning();
            DownloadHintLabel.Text = "Download format";
            VersionLabel.Text = "Game version";
            KeyLabel.Text = "Decryption key";
            LocationLabel.Text = $"Download location: {launcherDirectory}";
            TryLoadKeyFromFile();
            UpdateLaunchState();
            UpdateExtractionFolderState();
        }

        private async void GetButton_Click(object sender, EventArgs e)
        {
            var selectedFileType = TypeOfFile.SelectedItem?.ToString();
            if (string.Equals(selectedFileType, "CLEAN", StringComparison.OrdinalIgnoreCase))
            {
                await ClearTemporaryDownloadsAsync();
                return;
            }

            var normalizedKey = NormalizeKey(CDKeyInput.Text);
            CDKeyInput.Text = normalizedKey;

            if (string.IsNullOrWhiteSpace(normalizedKey))
            {
                MessageBox.Show("Please enter a decryption key.");
                return;
            }

            if (normalizedKey.Length != 32)
            {
                MessageBox.Show("The decryption key must contain exactly 32 characters.");
                return;
            }

            await StartDownloadAsync();
        }

        private async Task StartDownloadAsync()
        {
            var selectedVersion = KSP_Version.SelectedItem?.ToString();
            var selectedFileType = TypeOfFile.SelectedItem?.ToString();
            var cdKey = NormalizeKey(CDKeyInput.Text);

            if (string.IsNullOrWhiteSpace(selectedVersion))
            {
                MessageBox.Show("Please select a KSP version.");
                return;
            }

            if (!string.Equals(selectedVersion, SupportedVersion, StringComparison.Ordinal))
            {
                MessageBox.Show("Unsupported KSP version.");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedFileType))
            {
                MessageBox.Show("Please select a file type.");
                return;
            }

            if (!downloadPresets.TryGetValue(selectedFileType, out var preset))
            {
                MessageBox.Show("Unknown file type.");
                return;
            }

            var downloadFolder = launcherDirectory;

            try
            {
                downloadCancellationTokenSource = new CancellationTokenSource();
                isDownloadInProgress = true;
                LockControls($"Preparing {selectedFileType} download...");
                Directory.CreateDirectory(downloadFolder);

                await DownloadPresetAsync(
                    preset,
                    downloadFolder,
                    cdKey,
                    downloadCancellationTokenSource.Token
                );

                if (string.Equals(selectedFileType, "SFX", StringComparison.OrdinalIgnoreCase))
                {
                    StartSfxExecutable(downloadFolder, cdKey);
                }
                else if (string.Equals(selectedFileType, ".7z", StringComparison.OrdinalIgnoreCase))
                {
                    ExtractSevenZipArchive(downloadFolder, cdKey);
                }

                MessageBox.Show(
                    $"Download complete.\nFiles saved in:\n{downloadFolder}",
                    "KSP Download Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                OpenExtractionFolderButton.Enabled = Directory.Exists(GetExtractedFolderPath());
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Download failed:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                isDownloadInProgress = false;
                downloadCancellationTokenSource?.Dispose();
                downloadCancellationTokenSource = null;
                UnlockControls();
                UpdateLaunchState();
                UpdateExtractionFolderState();
            }
        }

        private async Task DownloadPresetAsync(
            DownloadPreset preset,
            string destinationFolder,
            string cdKey,
            CancellationToken cancellationToken
        )
        {
            var totalFiles = preset.Files.Length;

            for (var index = 0; index < totalFiles; index++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var fileName = preset.Files[index];
                var sourceUrl = BuildGithubMediaUrl(preset.RepositoryFolder, fileName);
                var destinationPath = Path.Combine(destinationFolder, fileName);

                SetStatus($"Downloading {fileName} ({index + 1}/{totalFiles})");

                await DownloadFileAsync(
                    sourceUrl,
                    destinationPath,
                    fileProgress =>
                    {
                        var globalProgress = ((index + fileProgress) / totalFiles) * 1000d;
                        SetProgress((int)Math.Round(globalProgress));
                    },
                    cancellationToken
                );
            }

            SetStatus("Download complete");
            SetProgress(ProgressBar.Maximum);
        }

        private static string BuildGithubMediaUrl(string repositoryFolder, string fileName)
        {
            var relativePath = $"{RepositoryVersionPath}/{repositoryFolder}/{fileName}";
            var escapedSegments = relativePath
                .Split('/')
                .Select(Uri.EscapeDataString);

            return $"https://media.githubusercontent.com/media/{RepositoryOwner}/{RepositoryName}/{RepositoryCommit}/{string.Join("/", escapedSegments)}";
        }

        private static string BuildPasswordArgument(string cdKey)
        {
            return $"-p{cdKey}";
        }

        private static async Task DownloadFileAsync(
            string sourceUrl,
            string destinationPath,
            Action<double> reportProgress,
            CancellationToken cancellationToken
        )
        {
            using var response = await HttpClient.GetAsync(
                sourceUrl,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            );
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength;

            await using var input = await response.Content.ReadAsStreamAsync(cancellationToken);
            await using var output = new FileStream(
                destinationPath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None
            );

            var buffer = new byte[81920];
            long totalBytesRead = 0;
            int bytesRead;

            while (
                (bytesRead = await input.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken)) > 0
            )
            {
                await output.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);
                totalBytesRead += bytesRead;

                if (totalBytes is > 0)
                {
                    reportProgress(totalBytesRead / (double)totalBytes.Value);
                }
            }

            reportProgress(1);
        }

        private void LockControls(string status)
        {
            GetButton.Enabled = false;
            KSP_Version.Enabled = false;
            TypeOfFile.Enabled = false;
            CDKeyInput.Enabled = false;
            CloseButton.Enabled = false;
            LaunchButton.Enabled = false;
            
            SetStatus(status);
            SetProgress(0);
        }

        private void UnlockControls()
        {
            GetButton.Enabled = true;
            KSP_Version.Enabled = true;
            TypeOfFile.Enabled = true;
            CDKeyInput.Enabled = true;
            CloseButton.Enabled = true;
            GetButton.Font = new System.Drawing.Font(GetButton.Font.FontFamily, 15);
            GetButton.Text = TypeOfFile.SelectedItem?.ToString() == "CLEAN" ? "Clean" : "Download";
       
            UpdateLaunchState();
            UpdateExtractionFolderState();
        }

        private void SetStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetStatus(status));
                return;
            }

            GetButton.Font = new System.Drawing.Font(GetButton.Font.FontFamily, 8);
            GetButton.Text = status;
        }

        private void SetProgress(int value)
        {
            var boundedValue = Math.Max(ProgressBar.Minimum, Math.Min(ProgressBar.Maximum, value));

            if (InvokeRequired)
            {
                Invoke(() => SetProgress(boundedValue));
                return;
            }

            ProgressBar.Value = boundedValue;
        }

        private void UpdateStartupWarning()
        {
            SetKeyWarningText("A valid 32-character decryption key is required.");

            if (HasDownloadedFiles())
            {
                SetTmpWarningText("Downloaded KSP files were detected in the launcher folder.");
                return;
            }

            SetTmpWarningText("Downloads will be saved next to this launcher.");
        }

        private bool HasDownloadedFiles()
        {
            if (!Directory.Exists(launcherDirectory))
            {
                return false;
            }

            return GetManagedArtifacts().Any(File.Exists) || Directory.Exists(GetExtractedFolderPath());
        }

        private void SetKeyWarningText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetKeyWarningText(text));
                return;
            }

            WarningLabel.ForeColor = System.Drawing.Color.Red;
            WarningLabel.Text = text;
        }

        private void SetTmpWarningText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(() => SetTmpWarningText(text));
                return;
            }

            TmpWarning.Text = text;
        }

        private void TryLoadKeyFromFile()
        {
            if (LauncherEnvironment.TryReadDecryptionKey(out var detectedKey, out var sourcePath))
            {
                autoDetectedKeyPath = sourcePath;
                CDKeyInput.Text = NormalizeKey(detectedKey);
                KeyStatusLabel.Text = $"Key detected automatically from {Path.GetFileName(sourcePath)}";
                KeyStatusLabel.ForeColor = Color.FromArgb(34, 197, 94);
                return;
            }

            autoDetectedKeyPath = string.Empty;
            KeyStatusLabel.Text = "No key file detected. Paste your 32-character key here.";
            KeyStatusLabel.ForeColor = Color.FromArgb(191, 201, 212);
        }

        private async void UncryptKey_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (isClosingAfterCleanup || !isDownloadInProgress)
            {
                return;
            }

            e.Cancel = true;
            LockControls("Cancelling download...");
            downloadCancellationTokenSource?.Cancel();

            await CleanupTemporaryFilesAsync(includeInstalledFiles: true);

            isClosingAfterCleanup = true;
            Close();
        }

        private async Task CleanupTemporaryFilesAsync(bool includeInstalledFiles)
        {
            try
            {
                await WaitForDownloadShutdownAsync();

                foreach (var artifactPath in GetManagedArtifacts())
                {
                    if (File.Exists(artifactPath))
                    {
                        File.Delete(artifactPath);
                    }
                }

                if (includeInstalledFiles)
                {
                    var extractedFolder = GetExtractedFolderPath();
                    if (Directory.Exists(extractedFolder))
                    {
                        Directory.Delete(extractedFolder, true);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                UpdateStartupWarning();
                UpdateLaunchState();
            }
        }

        private void UpdateExtractionFolderState()
        {
            var extractedFolder = GetExtractedFolderPath();
            var exists = Directory.Exists(extractedFolder);
            OpenExtractionFolderButton.Enabled = exists;
            ExtractionStatusLabel.Text = exists
                ? $"Extracted files: {extractedFolder}"
                : "No extracted KSP folder detected yet.";
        }

        private async Task ClearTemporaryDownloadsAsync()
        {
            try
            {
                LockControls("Cleaning archive files...");
                await CleanupTemporaryFilesAsync(includeInstalledFiles: false);
                MessageBox.Show(
                    "Downloaded archive files were removed.\nYour extracted game files were kept.",
                    "Cleanup Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to clear temporary files:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                UnlockControls();
            }
        }

        private async Task WaitForDownloadShutdownAsync()
        {
            const int maxAttempts = 50;

            for (var attempt = 0; attempt < maxAttempts && isDownloadInProgress; attempt++)
            {
                await Task.Delay(100);
            }
        }

        private static void StartSfxExecutable(string downloadFolder, string cdKey)
        {
            var sfxPath = Path.Combine(downloadFolder, "Kerbal Space Program.exe");

            if (!File.Exists(sfxPath))
            {
                throw new FileNotFoundException("The SFX executable was not found after download.", sfxPath);
            }

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = sfxPath,
                    Arguments = BuildPasswordArgument(cdKey),
                    UseShellExecute = true,
                    WorkingDirectory = downloadFolder,
                }
            );
        }

        private static void ExtractSevenZipArchive(string downloadFolder, string cdKey)
        {
            var archivePath = Path.Combine(downloadFolder, "Kerbal Space Program.7z.001");
            if (!File.Exists(archivePath))
            {
                throw new FileNotFoundException("The first archive part was not found after download.", archivePath);
            }

            var sevenZipPath = FindSevenZipExecutable();
            if (string.IsNullOrWhiteSpace(sevenZipPath))
            {
                throw new FileNotFoundException(
                    "7z.exe was not found. Install 7-Zip or add 7z.exe to PATH to extract the archive automatically."
                );
            }

            var outputFolder = Path.Combine(downloadFolder, "KSP-Extracted");
            Directory.CreateDirectory(outputFolder);

            var process = Process.Start(
                new ProcessStartInfo
                {
                    FileName = sevenZipPath,
                    Arguments = $"x \"{archivePath}\" {BuildPasswordArgument(cdKey)} -o\"{outputFolder}\" -y",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = downloadFolder,
                }
            );

            if (process == null)
            {
                throw new Win32Exception("Failed to start 7z.exe.");
            }

            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException($"7z extraction failed with exit code {process.ExitCode}.");
            }
        }

        private static string? FindSevenZipExecutable()
        {
            var candidates = new[]
            {
                "7z.exe",
                "7zz.exe",
                @"C:\Program Files\7-Zip\7z.exe",
                @"C:\Program Files (x86)\7-Zip\7z.exe",
            };

            foreach (var candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            return null;
        }

        private string[] GetManagedArtifacts()
        {
            return LauncherEnvironment.GetArchiveArtifactPaths(launcherDirectory);
        }

        private string GetExtractedFolderPath()
        {
            return LauncherEnvironment.GetExtractedFolderPath(launcherDirectory);
        }

        private void UpdateLaunchState()
        {
            var kspPath = FindKspExecutable();
            var canLaunch = !string.IsNullOrWhiteSpace(kspPath);
            LaunchButton.Enabled = canLaunch && !isDownloadInProgress;
            LaunchStatusLabel.Text = canLaunch ? $"Ready: {Path.GetDirectoryName(kspPath)}" : "KSP_x64.exe not found yet";
            
            AutoKeyPathLabel.Text = string.IsNullOrWhiteSpace(autoDetectedKeyPath)
                ? "Key file: not detected"
                : $"Key file: {autoDetectedKeyPath}";
        }

        private string? FindKspExecutable()
        {
            return LauncherEnvironment.FindKspExecutable(launcherDirectory);
        }

        private void KSPVersionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeOfFile.SelectedItem?.ToString() == "CLEAN")
            {
                GetButton.Text = "Clean";
            }
            else if (!isDownloadInProgress)
            {
                GetButton.Text = "Download";
            }
        }

        private void WarningLabel_Click(object sender, EventArgs e)
        {
        }

        private void KeyInput_TextChanged(object sender, EventArgs e)
        {
            var currentSelection = CDKeyInput.SelectionStart;
            var normalized = NormalizeKey(CDKeyInput.Text);

            if (!string.Equals(CDKeyInput.Text, normalized, StringComparison.Ordinal))
            {
                CDKeyInput.Text = normalized;
                CDKeyInput.SelectionStart = Math.Min(currentSelection, CDKeyInput.TextLength);
            }

            SetKeyWarningText(
                normalized.Length == 32
                    ? "Key format looks valid."
                    : "A valid 32-character decryption key is required."
            );
        }

        private void progressBar_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void WarningLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenExtractionFolderButton_Click(object sender, EventArgs e)
        {
            var extractedFolder = GetExtractedFolderPath();
            if (!Directory.Exists(extractedFolder))
            {
                MessageBox.Show(
                    "No extracted KSP folder is available yet.",
                    "Folder Unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                UpdateExtractionFolderState();
                return;
            }

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = extractedFolder,
                    UseShellExecute = true,
                }
            );
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            var kspPath = FindKspExecutable();
            if (string.IsNullOrWhiteSpace(kspPath))
            {
                MessageBox.Show(
                    "KSP_x64.exe was not found yet. Extract or install the game first.",
                    "KSP Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                UpdateLaunchState();
                return;
            }

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = kspPath,
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetDirectoryName(kspPath) ?? launcherDirectory,
                }
            );

            if (GetManagedArtifacts().Any(File.Exists))
            {
                var cleanupNow = MessageBox.Show(
                    "KSP launch started.\nRemove the downloaded archive files now?\nYour installed game files will be kept.",
                    "Clean Download Files",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (cleanupNow == DialogResult.Yes)
                {
                    _ = CleanupTemporaryFilesAsync(includeInstalledFiles: false);
                }
            }
        }

        private sealed record DownloadPreset(string RepositoryFolder, string[] Files);

        private static string NormalizeKey(string key)
        {
            return Regex.Replace(key ?? string.Empty, "[^A-Za-z0-9]", string.Empty)
                .Trim()
                .ToUpperInvariant();
        }

        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
