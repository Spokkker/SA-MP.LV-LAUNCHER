using System.Collections.ObjectModel;
using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;
using Launcher.UI.Commands;

namespace Launcher.UI.ViewModels;

public sealed class ModsViewModel : BaseViewModel
{
    private readonly IModService _modService;
    private readonly IConfigurationService _configurationService;
    private readonly ILogService _logService;
    private readonly string _configurationPath;
    private AppConfiguration _configuration;
    private bool _isBusy;

    public ObservableCollection<ModState> Mods { get; } = new();

    public RelayCommand EnableModCommand { get; }
    public RelayCommand DisableModCommand { get; }
    public RelayCommand RefreshCommand { get; }

    public ModsViewModel(IModService modService, IConfigurationService configurationService, ILogService logService, AppConfiguration configuration, string configurationPath)
    {
        _modService = modService;
        _configurationService = configurationService;
        _logService = logService;
        _configuration = configuration;
        _configurationPath = configurationPath;

        foreach (var mod in configuration.Mods)
        {
            Mods.Add(mod);
        }

        EnableModCommand = new RelayCommand(async modName => await ToggleAsync(modName as string ?? string.Empty, true));
        DisableModCommand = new RelayCommand(async modName => await ToggleAsync(modName as string ?? string.Empty, false));
        RefreshCommand = new RelayCommand(_ => Refresh());
    }

    public void ApplyConfiguration(AppConfiguration configuration)
    {
        _configuration = configuration;
        Refresh();
    }

    private void Refresh()
    {
        Mods.Clear();
        foreach (var mod in _configuration.Mods)
        {
            Mods.Add(mod);
        }
    }

    private async Task ToggleAsync(string modName, bool enabled)
    {
        if (_isBusy || string.IsNullOrWhiteSpace(modName))
        {
            return;
        }

        _isBusy = true;
        try
        {
            if (enabled)
            {
                await _modService.EnableModAsync(modName, _configuration);
            }
            else
            {
                await _modService.DisableModAsync(modName, _configuration);
            }

            await _configurationService.SaveAsync(_configurationPath, _configuration);
            _logService.LogInformation($"Mod '{modName}' {(enabled ? "enabled" : "disabled")}");
            Refresh();
        }
        catch (Exception ex)
        {
            _logService.LogError("Failed to toggle mod", ex);
        }
        finally
        {
            _isBusy = false;
        }
    }
}
