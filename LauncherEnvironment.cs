using System.Text.Json;

namespace KSP_DL;

public static class LauncherEnvironment
{
    internal const string KeyFileName = "uncrypt_key";
    internal const string ExtractedFolderName = "KSP-Extracted";

    public static readonly string[] ArchivePartNames =
    {
        "Kerbal Space Program.7z.001",
        "Kerbal Space Program.7z.002",
        "Kerbal Space Program.7z.003",
        "Kerbal Space Program.7z.004",
        "Kerbal Space Program.7z.005",
        "Kerbal Space Program.exe",
    };

    public static string LauncherDirectory => AppContext.BaseDirectory;

    public static string[] GetKeyFileCandidates()
    {
        var candidates = new[]
        {
            Path.Combine(AppContext.BaseDirectory, KeyFileName),
            Path.Combine(Environment.CurrentDirectory, KeyFileName),
        };
        return candidates.Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
    }

    public static bool TryReadDecryptionKey(out string key, out string sourcePath)
    {
        foreach (var path in GetKeyFileCandidates())
        {
            if (!File.Exists(path))
            {
                continue;
            }

            try
            {
                using var document = JsonDocument.Parse(File.ReadAllText(path));
                if (document.RootElement.TryGetProperty("uncrypt_key", out var keyElement) &&
                    keyElement.ValueKind == JsonValueKind.String)
                {
                    var loadedKey = keyElement.GetString()?.Trim() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(loadedKey))
                    {
                        key = loadedKey;
                        sourcePath = path;
                        return true;
                    }
                }
            }
            catch
            {
            }
        }

        key = string.Empty;
        sourcePath = string.Empty;
        return false;
    }

    public static string[] GetArchiveArtifactPaths(string baseDirectory)
    {
        return ArchivePartNames.Select(fileName => Path.Combine(baseDirectory, fileName)).ToArray();
    }

    public static bool HasArchiveDownloads(string baseDirectory)
    {
        return GetArchiveArtifactPaths(baseDirectory).Any(File.Exists);
    }

    public static string GetExtractedFolderPath(string baseDirectory)
    {
        return Path.Combine(baseDirectory, ExtractedFolderName);
    }

    public static string? FindKspExecutable(string baseDirectory)
    {
        var directCandidates = new[]
        {
            Path.Combine(baseDirectory, "KSP_x64.exe"),
            Path.Combine(baseDirectory, ExtractedFolderName, "KSP_x64.exe"),
            Path.Combine(baseDirectory, ExtractedFolderName, "Kerbal Space Program", "KSP_x64.exe"),
        };

        foreach (var candidate in directCandidates)
        {
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        return !Directory.Exists(baseDirectory)
            ? null
            : Directory.EnumerateFiles(baseDirectory, "KSP_x64.exe", SearchOption.AllDirectories).FirstOrDefault();
    }
}
