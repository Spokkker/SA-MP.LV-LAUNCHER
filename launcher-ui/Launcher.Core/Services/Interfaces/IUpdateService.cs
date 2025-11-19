namespace Launcher.Core.Services.Interfaces;

public interface IUpdateService
{
    Task<bool> CheckForUpdatesAsync(Version currentVersion, Uri manifestUri, CancellationToken cancellationToken = default);
    Task ApplyUpdateAsync(Uri packageUri, string downloadPath, CancellationToken cancellationToken = default);
}
