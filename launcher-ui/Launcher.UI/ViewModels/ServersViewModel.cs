using System.Collections.ObjectModel;
using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;
using Launcher.UI.Commands;

namespace Launcher.UI.ViewModels;

public sealed class ServersViewModel : BaseViewModel
{
    private readonly IServerService _serverService;
    private readonly ILogService _logService;
    private AppConfiguration _configuration;
    private bool _isPinging;

    public ObservableCollection<ServerEntry> Servers { get; } = new();
    public RelayCommand PingCommand { get; }
    public RelayCommand ConnectCommand { get; }

    public ServersViewModel(IServerService serverService, ILogService logService, AppConfiguration configuration)
    {
        _serverService = serverService;
        _logService = logService;
        _configuration = configuration;

        foreach (var server in configuration.Servers)
        {
            Servers.Add(server);
        }

        PingCommand = new RelayCommand(async server => await PingAsync(server as ServerEntry), _ => !_isPinging);
        ConnectCommand = new RelayCommand(server => Connect(server as ServerEntry));
    }

    public void ApplyConfiguration(AppConfiguration configuration)
    {
        _configuration = configuration;
        Servers.Clear();
        foreach (var server in configuration.Servers)
        {
            Servers.Add(server);
        }
    }

    private async Task PingAsync(ServerEntry? server)
    {
        if (server is null)
        {
            return;
        }

        _isPinging = true;
        PingCommand.RaiseCanExecuteChanged();
        try
        {
            await _serverService.PingServerAsync(server);
            Servers[Servers.IndexOf(server)] = server;
        }
        finally
        {
            _isPinging = false;
            PingCommand.RaiseCanExecuteChanged();
        }
    }

    private void Connect(ServerEntry? server)
    {
        if (server is null)
        {
            return;
        }

        var connectionString = _serverService.BuildConnectionString(server);
        _logService.LogInformation($"Connecting to {connectionString}");
    }
}
