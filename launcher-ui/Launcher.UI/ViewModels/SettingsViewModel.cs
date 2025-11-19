using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;
using Launcher.UI.Commands;

namespace Launcher.UI.ViewModels;

public sealed class SettingsViewModel : BaseViewModel
{
    private readonly IConfigurationService _configurationService;
    private readonly ILogService _logService;
    private readonly string _configurationPath;
    private AppConfiguration _configuration;
    private string _backupPath = string.Empty;

    public string GamePath
    {
        get => _configuration.GamePath;
        set
        {
            _configuration.GamePath = value;
            OnPropertyChanged();
        }
    }

    public string ModsPath
    {
        get => _configuration.ModsPath;
        set
        {
            _configuration.ModsPath = value;
            OnPropertyChanged();
        }
    }

    public string Language
    {
        get => _configuration.Language;
        set
        {
            _configuration.Language = value;
            OnPropertyChanged();
        }
    }

    public bool AutoUpdateEnabled
    {
        get => _configuration.AutoUpdateEnabled;
        set
        {
            _configuration.AutoUpdateEnabled = value;
            OnPropertyChanged();
        }
    }

    public string BackupPath
    {
        get => _backupPath;
        set => SetProperty(ref _backupPath, value);
    }

    public RelayCommand SaveCommand { get; }
    public RelayCommand BackupCommand { get; }
    public RelayCommand RestoreCommand { get; }

    public SettingsViewModel(IConfigurationService configurationService, ILogService logService, AppConfiguration configuration, string configurationPath)
    {
        _configurationService = configurationService;
        _logService = logService;
        _configuration = configuration;
        _configurationPath = configurationPath;

        SaveCommand = new RelayCommand(async _ => await SaveAsync());
        BackupCommand = new RelayCommand(async _ => await BackupAsync());
        RestoreCommand = new RelayCommand(async backup => await RestoreAsync(backup as string ?? BackupPath));
    }

    public void ApplyConfiguration(AppConfiguration configuration)
    {
        _configuration = configuration;
        OnPropertyChanged(nameof(GamePath));
        OnPropertyChanged(nameof(ModsPath));
        OnPropertyChanged(nameof(Language));
        OnPropertyChanged(nameof(AutoUpdateEnabled));
    }

    private async Task SaveAsync()
    {
        await _configurationService.SaveAsync(_configurationPath, _configuration);
        _logService.LogInformation("Configuration saved.");
    }

    private async Task BackupAsync()
    {
        try
        {
            var backupPath = await _configurationService.BackupAsync(_configurationPath);
            BackupPath = backupPath;
            _logService.LogInformation($"Backup created at {backupPath}");
        }
        catch (Exception ex)
        {
            _logService.LogError("Failed to back up configuration", ex);
        }
    }

    private async Task RestoreAsync(string backupPath)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(backupPath))
            {
                _logService.LogError("No backup path provided");
                return;
            }

            await _configurationService.RestoreAsync(backupPath, _configurationPath);
            var restored = await _configurationService.LoadAsync(_configurationPath);
            ApplyConfiguration(restored);
            _logService.LogInformation("Configuration restored from backup.");
        }
        catch (Exception ex)
        {
            _logService.LogError("Failed to restore configuration", ex);
        }
    }
}
