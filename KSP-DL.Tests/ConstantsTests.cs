namespace KSP_DL.Tests;

public class ConstantsTests
{
    [Fact]
    public void SupportedVersion_ShouldBeLatestKspVersion()
    {
        Assert.Equal("Kerbal Space Program 1.12.5.3190 (latest)", KspConstants.SupportedVersion);
    }

    [Fact]
    public void RepositoryOwner_ShouldBeCorrect()
    {
        Assert.Equal("Yel0w08", KspConstants.RepositoryOwner);
    }

    [Fact]
    public void RepositoryName_ShouldBeCorrect()
    {
        Assert.Equal("storage.archive.data", KspConstants.RepositoryName);
    }

    [Fact]
    public void ArchiveParts_ShouldHaveFiveParts()
    {
        Assert.Equal(5, KspConstants.ArchiveParts.Length);
        Assert.All(KspConstants.ArchiveParts, part => Assert.Contains(".7z.00", part));
    }

    [Fact]
    public void CkanDownloadUrl_ShouldBeValidGitHubUrl()
    {
        Assert.StartsWith("https://github.com/KSP-CKAN/CKAN/releases/", KspConstants.CkanDownloadUrl);
        Assert.EndsWith("CKAN.exe", KspConstants.CkanDownloadUrl);
    }
}
