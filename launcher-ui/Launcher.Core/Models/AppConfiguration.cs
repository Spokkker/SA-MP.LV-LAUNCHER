namespace Launcher.Core.Models;

public sealed class AppConfiguration
{
    public string GamePath { get; set; } = string.Empty;
    public string ModsPath { get; set; } = string.Empty;
    public string Language { get; set; } = "en";
    public bool AutoUpdateEnabled { get; set; } = true;
    public List<ModState> Mods { get; set; } = new();
    public List<ServerEntry> Servers { get; set; } = new();
}
