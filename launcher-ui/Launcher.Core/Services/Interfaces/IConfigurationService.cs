using Launcher.Core.Models;

namespace Launcher.Core.Services.Interfaces;

public interface IConfigurationService
{
    Task<AppConfiguration> LoadAsync(string path, CancellationToken cancellationToken = default);
    Task SaveAsync(string path, AppConfiguration configuration, CancellationToken cancellationToken = default);
    Task<string> BackupAsync(string path, CancellationToken cancellationToken = default);
    Task RestoreAsync(string backupPath, string destinationPath, CancellationToken cancellationToken = default);
}
