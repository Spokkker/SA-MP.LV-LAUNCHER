using Launcher.Core.Models;

namespace Launcher.Core.Services.Interfaces;

public interface IModService
{
    Task<ModManifest> ParseManifestAsync(Stream manifestStream, CancellationToken cancellationToken = default);
    Task<ModManifest> ParseManifestAsync(string json, CancellationToken cancellationToken = default);
    Task DownloadModAsync(ModManifest manifest, string modsDirectory, CancellationToken cancellationToken = default);
    Task<bool> ValidateHashAsync(string filePath, string expectedSha256, CancellationToken cancellationToken = default);
    Task EnableModAsync(string modName, AppConfiguration configuration, CancellationToken cancellationToken = default);
    Task DisableModAsync(string modName, AppConfiguration configuration, CancellationToken cancellationToken = default);
}
