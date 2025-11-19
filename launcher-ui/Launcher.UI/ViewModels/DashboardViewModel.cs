using Launcher.Core.Services.Interfaces;
using Launcher.UI.Commands;

namespace Launcher.UI.ViewModels;

public sealed class DashboardViewModel : BaseViewModel
{
    private readonly IUpdateService _updateService;
    private readonly ILogService _logService;
    private string _status = "Ready";
    private bool _isChecking;

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public RelayCommand PlayCommand { get; }
    public RelayCommand CheckUpdatesCommand { get; }

    public DashboardViewModel(IUpdateService updateService, ILogService logService)
    {
        _updateService = updateService;
        _logService = logService;

        PlayCommand = new RelayCommand(_ => _logService.LogInformation("Launching game..."));
        CheckUpdatesCommand = new RelayCommand(async _ => await CheckUpdatesAsync(), _ => !_isChecking);
    }

    private async Task CheckUpdatesAsync()
    {
        _isChecking = true;
        CheckUpdatesCommand.RaiseCanExecuteChanged();
        try
        {
            Status = "Checking updates...";
            var needsUpdate = await _updateService.CheckForUpdatesAsync(new Version(1, 0, 0), new Uri("https://example.com/manifest.json"));
            Status = needsUpdate ? "Update available" : "Up to date";
        }
        catch (Exception ex)
        {
            Status = "Update check failed";
            _logService.LogError(Status, ex);
        }
        finally
        {
            _isChecking = false;
            CheckUpdatesCommand.RaiseCanExecuteChanged();
        }
    }
}
