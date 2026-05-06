using System.Diagnostics;

namespace KSP_DL;

public static class ArchiveExtractor
{
    internal static void StartSfxExecutable(string downloadFolder, string cdKey)
    {
        var sfxPath = Path.Combine(downloadFolder, "Kerbal Space Program.exe");

        if (!File.Exists(sfxPath))
        {
            throw new FileNotFoundException("The SFX executable was not found after download.", sfxPath);
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = sfxPath,
            Arguments = BuildPasswordArgument(cdKey),
            UseShellExecute = true,
            WorkingDirectory = downloadFolder,
        });
    }

    internal static void ExtractSevenZipArchive(string downloadFolder, string cdKey)
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

        using var process = Process.Start(new ProcessStartInfo
        {
            FileName = sevenZipPath,
            Arguments = $"x \"{archivePath}\" {BuildPasswordArgument(cdKey)} -o\"{outputFolder}\" -y",
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = downloadFolder,
        });

        if (process == null)
        {
            throw new InvalidOperationException("Failed to start 7z.exe.");
        }

        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"7z extraction failed with exit code {process.ExitCode}.");
        }
    }

    private static string BuildPasswordArgument(string cdKey)
    {
        return $"-p{cdKey}";
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
}
