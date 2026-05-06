using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace KSP_DL;

public sealed class KspDownloadService : IDisposable
{
    private static readonly HttpClient HttpClient = new();
    private const int BufferSize = 81920;

    public DownloadPreset[] GetDownloadPresets()
    {
        return
        [
            new DownloadPreset("7zip_Archive", KspConstants.ArchiveParts),
            new DownloadPreset(
                "Self_Extracting",
                KspConstants.ArchiveParts.Concat(["Kerbal Space Program.exe"]).ToArray()
            ),
        ];
    }

    internal async Task DownloadPresetAsync(
        DownloadPreset preset,
        string destinationFolder,
        string cdKey,
        IProgress<double> progress,
        CancellationToken cancellationToken
    )
    {
        var totalFiles = preset.Files.Length;
        long totalBytesDownloaded = 0;

        for (var index = 0; index < totalFiles; index++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var fileName = preset.Files[index];
            var sourceUrl = BuildGithubMediaUrl(preset.RepositoryFolder, fileName);
            var destinationPath = Path.Combine(destinationFolder, fileName);

            var fileBytes = await DownloadFileWithProgressAsync(
                sourceUrl,
                destinationPath,
                cancellationToken
            );

            totalBytesDownloaded += fileBytes;

            var globalProgress = totalBytesDownloaded / (double)(totalBytesDownloaded + (totalFiles - index - 1) * 1024 * 1024);
            progress.Report(globalProgress);
        }
    }

    private static async Task<long> DownloadFileWithProgressAsync(
        string sourceUrl,
        string destinationPath,
        CancellationToken cancellationToken
    )
    {
        using var response = await HttpClient.GetAsync(
            sourceUrl,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken
        );
        response.EnsureSuccessStatusCode();

        await using var input = await response.Content.ReadAsStreamAsync(cancellationToken);
        await using var output = new FileStream(
            destinationPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None
        );

        var buffer = new byte[BufferSize];
        long totalBytesRead = 0;
        int bytesRead;

        while ((bytesRead = await input.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken)) > 0)
        {
            await output.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);
            totalBytesRead += bytesRead;
        }

        return totalBytesRead;
    }

    public static string NormalizeKey(string key)
    {
        return Regex.Replace(key ?? string.Empty, "[^A-Za-z0-9]", string.Empty)
            .Trim()
            .ToUpperInvariant();
    }

    public static string BuildGithubMediaUrl(string repositoryFolder, string fileName)
    {
        var relativePath = $"{KspConstants.RepositoryVersionPath}/{repositoryFolder}/{fileName}";
        var escapedSegments = relativePath
            .Split('/')
            .Select(Uri.EscapeDataString);

        return $"https://media.githubusercontent.com/media/{KspConstants.RepositoryOwner}/{KspConstants.RepositoryName}/{KspConstants.RepositoryCommit}/{string.Join("/", escapedSegments)}";
    }

    public void Dispose()
    {
        HttpClient.Dispose();
    }
}

public sealed record DownloadPreset(string RepositoryFolder, string[] Files);
