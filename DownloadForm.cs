using System.Diagnostics;
using System.Windows.Forms;

namespace KSP_DL;

public partial class DownloadForm : Form
{
    private readonly KspDownloadService downloadService = new();
    private readonly string launcherDirectory = LauncherEnvironment.LauncherDirectory;
    private readonly Dictionary<string, DownloadPreset> downloadPresets;
    private CancellationTokenSource? downloadCancellationTokenSource;
    private bool isDownloadInProgress;
    private bool isClosingAfterCleanup;
    private string autoDetectedKeyPath = string.Empty;

    public DownloadForm()
    {
        InitializeComponent();
        downloadPresets = downloadService.GetDownloadPresets()
            .ToDictionary(p => p.RepositoryFolder == "Self_Extracting" ? "SFX" : ".7z", StringComparer.OrdinalIgnoreCase);
    }

    private void DownloadForm_Load(object sender, EventArgs e)
    {
        InitializeUiState();
        TryLoadKeyFromFile();
        UpdateLaunchState();
        UpdateExtractionFolderState();
    }

    private void InitializeUiState()
    {
        ProgressBar.Minimum = 0;
        ProgressBar.Maximum = 1000;
        ProgressBar.Value = 0;
        KSP_Version.SelectedIndex = 0;
        TypeOfFile.SelectedIndex = 0;
        FormClosing += DownloadForm_FormClosing;
        DownloadHintLabel.Text = "Package format";
        VersionLabel.Text = "Game version";
        KeyLabel.Text = "Decryption key";
        LocationLabel.Text = $"Download location: {launcherDirectory}";
    }

    private async void GetButton_Click(object sender, EventArgs e)
    {
        var selectedFileType = TypeOfFile.SelectedItem?.ToString();
        if (string.Equals(selectedFileType, "CLEAN", StringComparison.OrdinalIgnoreCase))
        {
            await ClearTemporaryDownloadsAsync();
            return;
        }

        var normalizedKey = KspDownloadService.NormalizeKey(CDKeyInput.Text);
        CDKeyInput.Text = normalizedKey;

        if (string.IsNullOrWhiteSpace(normalizedKey) || normalizedKey.Length != 32)
        {
            MessageBox.Show(normalizedKey.Length != 32
                ? "The decryption key must contain exactly 32 characters."
                : "Please enter a decryption key.");
            return;
        }

        await StartDownloadAsync();
    }

    private async Task StartDownloadAsync()
    {
        var selectedVersion = KSP_Version.SelectedItem?.ToString();
        var selectedFileType = TypeOfFile.SelectedItem?.ToString();
        var cdKey = KspDownloadService.NormalizeKey(CDKeyInput.Text);

        if (!ValidateDownloadInputs(selectedVersion, selectedFileType, out var preset))
        {
            return;
        }

        try
        {
            downloadCancellationTokenSource = new CancellationTokenSource();
            isDownloadInProgress = true;
            LockControls($"Preparing {selectedFileType} download...");
            Directory.CreateDirectory(launcherDirectory);

            var progress = new Progress<double>(p =>
            {
                var value = (int)Math.Round(p * ProgressBar.Maximum);
                SetProgress(value);
            });

            SetStatus($"Downloading {selectedFileType}...");
            await downloadService.DownloadPresetAsync(
                preset,
                launcherDirectory,
                cdKey,
                progress,
                downloadCancellationTokenSource.Token
            );

            HandlePostDownloadActions(selectedFileType!, cdKey);
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Download failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CleanupAfterDownload();
        }
    }

    private bool ValidateDownloadInputs(string? selectedVersion, string? selectedFileType, out DownloadPreset preset)
    {
        preset = null!;

        if (string.IsNullOrWhiteSpace(selectedVersion) || !string.Equals(selectedVersion, KspConstants.SupportedVersion, StringComparison.Ordinal))
        {
            MessageBox.Show(string.IsNullOrWhiteSpace(selectedVersion) ? "Please select a KSP version." : "Unsupported KSP version.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(selectedFileType) || !downloadPresets.TryGetValue(selectedFileType, out preset))
        {
            MessageBox.Show(string.IsNullOrWhiteSpace(selectedFileType) ? "Please select a file type." : "Unknown file type.");
            return false;
        }

        return true;
    }

    private void HandlePostDownloadActions(string selectedFileType, string cdKey)
    {
        if (string.Equals(selectedFileType, "SFX", StringComparison.OrdinalIgnoreCase))
        {
            ArchiveExtractor.StartSfxExecutable(launcherDirectory, cdKey);
        }
        else if (string.Equals(selectedFileType, ".7z", StringComparison.OrdinalIgnoreCase))
        {
            ArchiveExtractor.ExtractSevenZipArchive(launcherDirectory, cdKey);
        }

        MessageBox.Show(
            $"Download complete.\nFiles saved in:\n{launcherDirectory}",
            "KSP Download Complete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );

        OpenExtractionFolderButton.Enabled = Directory.Exists(GetExtractedFolderPath());
    }

    private void CleanupAfterDownload()
    {
        isDownloadInProgress = false;
        downloadCancellationTokenSource?.Dispose();
        downloadCancellationTokenSource = null;
        UnlockControls();
        UpdateLaunchState();
        UpdateExtractionFolderState();
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
        SetTmpWarningText(HasDownloadedFiles()
            ? "Downloaded KSP files were detected in the launcher folder."
            : "Downloads will be saved next to this launcher.");
    }

    private bool HasDownloadedFiles()
    {
        return !Directory.Exists(launcherDirectory)
            ? false
            : GetManagedArtifacts().Any(File.Exists) || Directory.Exists(GetExtractedFolderPath());
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
            CDKeyInput.Text = KspDownloadService.NormalizeKey(detectedKey);
            KeyStatusLabel.Text = $"Key detected automatically from {Path.GetFileName(sourcePath)}";
            KeyStatusLabel.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            return;
        }

        autoDetectedKeyPath = string.Empty;
        KeyStatusLabel.Text = "No key file detected. Paste your 32-character key here.";
        KeyStatusLabel.ForeColor = System.Drawing.Color.FromArgb(191, 201, 212);
    }

    private async void DownloadForm_FormClosing(object? sender, FormClosingEventArgs e)
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

            if (includeInstalledFiles && Directory.Exists(GetExtractedFolderPath()))
            {
                Directory.Delete(GetExtractedFolderPath(), true);
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
            MessageBox.Show($"Failed to clear temporary files:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        var kspPath = LauncherEnvironment.FindKspExecutable(launcherDirectory);
        var canLaunch = !string.IsNullOrWhiteSpace(kspPath);
        LaunchButton.Enabled = canLaunch && !isDownloadInProgress;
        LaunchStatusLabel.Text = canLaunch ? $"Ready: {Path.GetDirectoryName(kspPath)}" : "KSP_x64.exe not found yet";
        AutoKeyPathLabel.Text = string.IsNullOrWhiteSpace(autoDetectedKeyPath)
            ? "Key file: not detected"
            : $"Key file: {autoDetectedKeyPath}";
    }

    private void KSPVersionComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
    private void FileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetButton.Text = TypeOfFile.SelectedItem?.ToString() == "CLEAN"
            ? "Clean"
            : !isDownloadInProgress ? "Download" : GetButton.Text;
    }

    private void WarningLabel_Click(object sender, EventArgs e) { }
    private void KeyInput_TextChanged(object sender, EventArgs e)
    {
        var currentSelection = CDKeyInput.SelectionStart;
        var normalized = KspDownloadService.NormalizeKey(CDKeyInput.Text);
        if (!string.Equals(CDKeyInput.Text, normalized, StringComparison.Ordinal))
        {
            CDKeyInput.Text = normalized;
            CDKeyInput.SelectionStart = Math.Min(currentSelection, CDKeyInput.TextLength);
        }

        SetKeyWarningText(normalized.Length == 32 ? "Key format looks valid." : "A valid 32-character decryption key is required.");
    }

    private void progressBar_Click(object sender, EventArgs e) { }
    private void HeaderPanel_Paint(object sender, PaintEventArgs e) { }
    private void WarningLabel_Click_1(object sender, EventArgs e) { }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void OpenExtractionFolderButton_Click(object sender, EventArgs e)
    {
        var extractedFolder = GetExtractedFolderPath();
        if (!Directory.Exists(extractedFolder))
        {
            MessageBox.Show("No extracted KSP folder is available yet.", "Folder Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateExtractionFolderState();
            return;
        }

        Process.Start(new ProcessStartInfo { FileName = extractedFolder, UseShellExecute = true });
    }

    private void LaunchButton_Click(object sender, EventArgs e)
    {
        var kspPath = LauncherEnvironment.FindKspExecutable(launcherDirectory);
        if (string.IsNullOrWhiteSpace(kspPath))
        {
            MessageBox.Show("KSP_x64.exe was not found yet. Extract or install the game first.", "KSP Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateLaunchState();
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = kspPath,
            UseShellExecute = true,
            WorkingDirectory = Path.GetDirectoryName(kspPath) ?? launcherDirectory,
        });

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
}
