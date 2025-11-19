namespace Launcher.Core.Models;

public sealed class ModManifest
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public Uri? DownloadUri { get; set; }
        = new("https://example.com");
    public string Sha256 { get; set; } = string.Empty;
    public bool EnabledByDefault { get; set; }
        = true;
}
