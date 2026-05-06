using System.Text.RegularExpressions;
using System.Linq;

namespace KSP_DL.Tests;

public class KspDownloadServiceTests
{
    [Theory]
    [InlineData("abcd1234efgh5678ijkl9012mnop3456", "ABCD1234EFGH5678IJKL9012MNOP3456")]
    [InlineData("abcd-1234-efgh-5678-ijkl-9012-mnop-3456", "ABCD1234EFGH5678IJKL9012MNOP3456")]
    [InlineData(" abcd 1234 efgh 5678 ", "ABCD1234EFGH5678")]
    [InlineData("ABCD1234EFGH5678IJKL9012MNOP3456", "ABCD1234EFGH5678IJKL9012MNOP3456")]
    public void NormalizeKey_ShouldRemoveNonAlphanumericAndUppercase(string input, string expected)
    {
        var result = KspDownloadService.NormalizeKey(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NormalizeKey_ShouldReturnEmptyForNull()
    {
        var result = KspDownloadService.NormalizeKey(null!);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void NormalizeKey_ShouldReturnEmptyForEmptyString()
    {
        var result = KspDownloadService.NormalizeKey(string.Empty);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void BuildGithubMediaUrl_ShouldReturnCorrectUrl()
    {
        var url = KspDownloadService.BuildGithubMediaUrl("Self_Extracting", "Kerbal Space Program.exe");
        
        Assert.Contains("media.githubusercontent.com", url);
        Assert.Contains("Yel0w08", url);
        Assert.Contains("storage.archive.data", url);
        Assert.Contains("Self_Extracting", url);
        Assert.Contains("Kerbal%20Space%20Program.exe", url);
    }

    [Fact]
    public void BuildGithubMediaUrl_ShouldEscapeSpaces()
    {
        var url = KspDownloadService.BuildGithubMediaUrl("7zip_Archive", "Kerbal Space Program.7z.001");
        
        Assert.Contains("Kerbal%20Space%20Program.7z.001", url);
    }

    [Fact]
    public void GetDownloadPresets_ShouldReturnTwoPresets()
    {
        using var service = new KspDownloadService();
        var presets = service.GetDownloadPresets();
        
        Assert.Equal(2, presets.Length);
        Assert.Contains(presets, p => p.RepositoryFolder == "Self_Extracting");
        Assert.Contains(presets, p => p.RepositoryFolder == "7zip_Archive");
    }

    [Fact]
    public void DownloadPreset_ShouldHaveCorrectFiles()
    {
        using var service = new KspDownloadService();
        var presets = service.GetDownloadPresets();
        
        var sfxPreset = presets.First(p => p.RepositoryFolder == "Self_Extracting");
        Assert.Contains("Kerbal Space Program.exe", sfxPreset.Files);
        Assert.Equal(6, sfxPreset.Files.Length);
        
        var zipPreset = presets.First(p => p.RepositoryFolder == "7zip_Archive");
        Assert.DoesNotContain("Kerbal Space Program.exe", zipPreset.Files);
        Assert.Equal(5, zipPreset.Files.Length);
    }
}
