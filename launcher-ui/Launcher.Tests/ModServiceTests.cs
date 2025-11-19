using System.Net.Http;
using System.Text;
using Launcher.Core.Models;
using Launcher.Core.Services;
using Launcher.Core.Services.Interfaces;
using Xunit;

namespace Launcher.Tests;

public sealed class ModServiceTests
{
    private sealed class TestLogService : ILogService
    {
        public event EventHandler<string>? MessageLogged;
        public void LogError(string message, Exception? exception = null) => MessageLogged?.Invoke(this, message);
        public void LogInformation(string message) => MessageLogged?.Invoke(this, message);
    }

    [Fact]
    public async Task ParseManifest_FromJsonString_ReturnsManifest()
    {
        var json = """
        {
            "name": "TestMod",
            "version": "1.2.3",
            "downloadUri": "https://example.com/mod.zip",
            "sha256": "ABC123"
        }
        """;

        var modService = new ModService(new HttpClient(), new TestLogService());
        var manifest = await modService.ParseManifestAsync(json);

        Assert.Equal("TestMod", manifest.Name);
        Assert.Equal("1.2.3", manifest.Version);
        Assert.Equal("ABC123", manifest.Sha256);
        Assert.Equal(new Uri("https://example.com/mod.zip"), manifest.DownloadUri);
    }

    [Fact]
    public async Task ValidateHash_ComputesExpectedHash()
    {
        var tempFile = Path.GetTempFileName();
        await File.WriteAllTextAsync(tempFile, "demo-content", Encoding.UTF8);
        var expectedHash = "E3CD3F32B5C4C7D592752ECBD726BFDABBA8CC0BB1B7F1C09A6DC36A69920536";
        var modService = new ModService(new HttpClient(), new TestLogService());

        var result = await modService.ValidateHashAsync(tempFile, expectedHash);

        Assert.True(result);
    }
}
