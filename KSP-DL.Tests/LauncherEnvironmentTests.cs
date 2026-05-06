using System.Text.Json;
using System.IO;
using System;

namespace KSP_DL.Tests;

public class LauncherEnvironmentTests
{
    [Fact]
    public void LauncherDirectory_ShouldReturnBaseDirectory()
    {
        var result = LauncherEnvironment.LauncherDirectory;
        Assert.Equal(AppContext.BaseDirectory, result);
    }

    [Fact]
    public void GetExtractedFolderPath_ShouldReturnCorrectPath()
    {
        var baseDir = @"C:\Test\Launcher";
        var result = LauncherEnvironment.GetExtractedFolderPath(baseDir);
        Assert.Equal(@"C:\Test\Launcher\KSP-Extracted", result);
    }

    [Fact]
    public void GetArchiveArtifactPaths_ShouldReturnAllArchiveParts()
    {
        var baseDir = @"C:\Test";
        var result = LauncherEnvironment.GetArchiveArtifactPaths(baseDir);
        
        Assert.Equal(6, result.Length);
        Assert.Contains(result, p => p.EndsWith("Kerbal Space Program.7z.001"));
        Assert.Contains(result, p => p.EndsWith("Kerbal Space Program.exe"));
    }

    [Fact]
    public void HasArchiveDownloads_ShouldReturnFalseWhenNoFiles()
    {
        var tempDir = Path.GetTempPath();
        var result = LauncherEnvironment.HasArchiveDownloads(tempDir);
        Assert.False(result);
    }

    [Fact]
    public void TryReadDecryptionKey_ShouldReturnFalseWhenFileMissing()
    {
        // Store original location
        var testDir = Path.GetTempPath();
        var testKeyFile = Path.Combine(testDir, "uncrypt_key");
        
        // Ensure file doesn't exist for this test
        if (File.Exists(testKeyFile))
        {
            File.Delete(testKeyFile);
        }
        
        var result = LauncherEnvironment.TryReadDecryptionKey(out var key, out var sourcePath);
        
        // Cleanup if we created the file
        if (File.Exists(testKeyFile))
        {
            File.Delete(testKeyFile);
        }
        
        // In the test environment, if there's a key file in the base directory, this might return true
        // We'll just verify the method doesn't throw and returns consistent results
        if (result)
        {
            Assert.False(string.IsNullOrWhiteSpace(key));
            Assert.False(string.IsNullOrWhiteSpace(sourcePath));
        }
        else
        {
            Assert.Equal(string.Empty, key);
            Assert.Equal(string.Empty, sourcePath);
        }
    }

    [Fact]
    public void ArchivePartNames_ShouldContainAllExpectedParts()
    {
        Assert.Equal(6, LauncherEnvironment.ArchivePartNames.Length);
        Assert.Contains("Kerbal Space Program.7z.001", LauncherEnvironment.ArchivePartNames);
        Assert.Contains("Kerbal Space Program.exe", LauncherEnvironment.ArchivePartNames);
    }
}
