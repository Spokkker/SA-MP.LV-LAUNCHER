using System.Security.Cryptography;
using System.Text.Json;
using Launcher.Core.Services.Interfaces;

namespace Launcher.Core.Services;

public sealed class UpdateService : IUpdateService
{
    private readonly HttpClient _httpClient;
    private readonly ILogService _logService;

    public UpdateService(HttpClient httpClient, ILogService logService)
    {
        _httpClient = httpClient;
        _logService = logService;
    }

    public async Task<bool> CheckForUpdatesAsync(Version currentVersion, Uri manifestUri, CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync(manifestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var document = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
        var latest = document.RootElement.GetProperty("version").GetString();

        if (Version.TryParse(latest, out var manifestVersion))
        {
            var requiresUpdate = manifestVersion > currentVersion;
            _logService.LogInformation(requiresUpdate
                ? $"Update available: {manifestVersion} (current {currentVersion})"
                : $"Launcher is up to date (version {currentVersion})");
            return requiresUpdate;
        }

        return false;
    }

    public async Task ApplyUpdateAsync(Uri packageUri, string downloadPath, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(downloadPath) ?? ".");
        using var response = await _httpClient.GetAsync(packageUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        await using (var fileStream = File.Create(downloadPath))
        await using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken))
        {
            await contentStream.CopyToAsync(fileStream, cancellationToken);
        }

        _logService.LogInformation($"Downloaded update package to {downloadPath}");
    }
}
