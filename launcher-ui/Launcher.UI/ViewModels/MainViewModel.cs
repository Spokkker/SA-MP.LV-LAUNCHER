using System.Collections.ObjectModel;
using Launcher.Core.Models;
using Launcher.Core.Services;
using Launcher.Core.Services.Interfaces;

namespace Launcher.UI.ViewModels;

public sealed class MainViewModel : BaseViewModel
{
    private readonly IConfigurationService _configurationService;
    private readonly ILogService _logService;
    private readonly string _configurationPath;

    public DashboardViewModel Dashboard { get; }
    public ModsViewModel Mods { get; }
    public ServersViewModel Servers { get; }
    public SettingsViewModel Settings { get; }

    public ObservableCollection<string> Logs { get; } = new();

    public MainViewModel()
    {
        _configurationPath = Path.Combine(AppContext.BaseDirectory, "config.json");
        _logService = new FileLogService(Path.Combine(AppContext.BaseDirectory, "logs"));
        _logService.MessageLogged += (_, message) => Logs.Insert(0, message);

        _configurationService = new FileConfigurationService();

        var configuration = new AppConfiguration
        {
            Servers = new List<ServerEntry>
            {
                new() { Name = "SA-MP.LV", Address = "samp.lv", Port = 7777 },
                new() { Name = "Localhost", Address = "127.0.0.1", Port = 7777 }
            }
        };

        var httpClient = new HttpClient();
        var modService = new ModService(httpClient, _logService);
        var serverService = new ServerService(_logService);
        var updateService = new UpdateService(httpClient, _logService);

        Dashboard = new DashboardViewModel(updateService, _logService);
        Mods = new ModsViewModel(modService, _configurationService, _logService, configuration, _configurationPath);
        Servers = new ServersViewModel(serverService, _logService, configuration);
        Settings = new SettingsViewModel(_configurationService, _logService, configuration, _configurationPath);
    }

    public async Task InitializeAsync()
    {
        try
        {
            var configuration = await _configurationService.LoadAsync(_configurationPath);
            Mods.ApplyConfiguration(configuration);
            Servers.ApplyConfiguration(configuration);
            Settings.ApplyConfiguration(configuration);
            _logService.LogInformation("Configuration loaded successfully.");
        }
        catch (Exception ex)
        {
            _logService.LogError("Failed to load configuration", ex);
        }
    }
}
