namespace Launcher.Core.Models;

public sealed class ModState
{
    public string Name { get; set; } = string.Empty;
    public bool Enabled { get; set; }
        = true;
    public string InstalledVersion { get; set; } = string.Empty;
}
