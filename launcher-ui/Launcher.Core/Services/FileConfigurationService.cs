using System.Text.Json;
using System.Text.Json.Serialization;
using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;

namespace Launcher.Core.Services;

public sealed class FileConfigurationService : IConfigurationService
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<AppConfiguration> LoadAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            return new AppConfiguration();
        }

        await using var stream = File.OpenRead(path);
        var configuration = await JsonSerializer.DeserializeAsync<AppConfiguration>(stream, _serializerOptions, cancellationToken)
                            ?? new AppConfiguration();
        return configuration;
    }

    public async Task SaveAsync(string path, AppConfiguration configuration, CancellationToken cancellationToken = default)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
        await using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, configuration, _serializerOptions, cancellationToken);
    }

    public async Task<string> BackupAsync(string path, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Configuration file not found", path);
        }

        var backupDirectory = Path.Combine(Path.GetDirectoryName(path) ?? ".", "backups");
        Directory.CreateDirectory(backupDirectory);
        var backupPath = Path.Combine(backupDirectory, $"config-{DateTime.UtcNow:yyyyMMdd-HHmmss}.json");
        await using var source = File.OpenRead(path);
        await using var destination = File.Create(backupPath);
        await source.CopyToAsync(destination, cancellationToken);
        return backupPath;
    }

    public async Task RestoreAsync(string backupPath, string destinationPath, CancellationToken cancellationToken = default)
    {
        if (!File.Exists(backupPath))
        {
            throw new FileNotFoundException("Backup not found", backupPath);
        }

        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? ".");
        await using var source = File.OpenRead(backupPath);
        await using var destination = File.Create(destinationPath);
        await source.CopyToAsync(destination, cancellationToken);
    }
}
