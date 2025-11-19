using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;

namespace Launcher.Core.Services;

public sealed class ModService : IModService
{
    private readonly HttpClient _httpClient;
    private readonly ILogService _logService;

    public ModService(HttpClient httpClient, ILogService logService)
    {
        _httpClient = httpClient;
        _logService = logService;
    }

    public async Task<ModManifest> ParseManifestAsync(Stream manifestStream, CancellationToken cancellationToken = default)
    {
        var manifest = await JsonSerializer.DeserializeAsync<ModManifest>(manifestStream, cancellationToken: cancellationToken)
                       ?? throw new InvalidOperationException("Failed to parse manifest.");
        return manifest;
    }

    public Task<ModManifest> ParseManifestAsync(string json, CancellationToken cancellationToken = default)
    {
        var manifest = JsonSerializer.Deserialize<ModManifest>(json)
                       ?? throw new InvalidOperationException("Failed to parse manifest.");
        return Task.FromResult(manifest);
    }

    public async Task DownloadModAsync(ModManifest manifest, string modsDirectory, CancellationToken cancellationToken = default)
    {
        if (manifest.DownloadUri is null)
        {
            throw new InvalidOperationException("Manifest is missing a download URL.");
        }

        Directory.CreateDirectory(modsDirectory);
        var targetFile = Path.Combine(modsDirectory, $"{manifest.Name}-{manifest.Version}.zip");
        using var request = new HttpRequestMessage(HttpMethod.Get, manifest.DownloadUri);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
        using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();

        await using (var fileStream = File.Create(targetFile))
        await using (var networkStream = await response.Content.ReadAsStreamAsync(cancellationToken))
        {
            await networkStream.CopyToAsync(fileStream, cancellationToken);
        }

        _logService.LogInformation($"Downloaded {manifest.Name} {manifest.Version} to {targetFile}");

        if (!string.IsNullOrWhiteSpace(manifest.Sha256))
        {
            var valid = await ValidateHashAsync(targetFile, manifest.Sha256, cancellationToken);
            if (!valid)
            {
                throw new CryptographicException("Downloaded mod failed integrity validation.");
            }
        }
    }

    public async Task<bool> ValidateHashAsync(string filePath, string expectedSha256, CancellationToken cancellationToken = default)
    {
        await using var stream = File.OpenRead(filePath);
        using var sha = SHA256.Create();
        var hash = await sha.ComputeHashAsync(stream, cancellationToken);
        var computed = Convert.ToHexString(hash);
        return string.Equals(computed, expectedSha256, StringComparison.OrdinalIgnoreCase);
    }

    public Task EnableModAsync(string modName, AppConfiguration configuration, CancellationToken cancellationToken = default)
    {
        ToggleMod(modName, configuration, enabled: true);
        return Task.CompletedTask;
    }

    public Task DisableModAsync(string modName, AppConfiguration configuration, CancellationToken cancellationToken = default)
    {
        ToggleMod(modName, configuration, enabled: false);
        return Task.CompletedTask;
    }

    private void ToggleMod(string modName, AppConfiguration configuration, bool enabled)
    {
        var mod = configuration.Mods.FirstOrDefault(m => string.Equals(m.Name, modName, StringComparison.OrdinalIgnoreCase));
        if (mod is null)
        {
            mod = new ModState { Name = modName };
            configuration.Mods.Add(mod);
        }

        mod.Enabled = enabled;
    }
}
