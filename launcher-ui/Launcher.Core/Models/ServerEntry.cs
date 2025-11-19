namespace Launcher.Core.Models;

public sealed class ServerEntry
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Port { get; set; } = 7777;
    public int? LastPing { get; set; }
        = null;
    public bool IsOnline { get; set; }
        = false;
}
