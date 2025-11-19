using System.Net.NetworkInformation;
using Launcher.Core.Models;
using Launcher.Core.Services.Interfaces;

namespace Launcher.Core.Services;

public sealed class ServerService : IServerService
{
    private readonly ILogService _logService;

    public ServerService(ILogService logService)
    {
        _logService = logService;
    }

    public Task<IReadOnlyCollection<ServerEntry>> GetServersAsync(AppConfiguration configuration, CancellationToken cancellationToken = default)
    {
        return Task.FromResult((IReadOnlyCollection<ServerEntry>)configuration.Servers.ToList());
    }

    public async Task<int?> PingServerAsync(ServerEntry server, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ping = new Ping();
            var reply = await ping.SendPingAsync(server.Address, 2000);
            server.IsOnline = reply.Status == IPStatus.Success;
            server.LastPing = reply.Status == IPStatus.Success ? (int?)reply.RoundtripTime : null;
            _logService.LogInformation($"Pinged {server.Address}:{server.Port} status {reply.Status} time {server.LastPing}");
            return server.LastPing;
        }
        catch (Exception ex)
        {
            _logService.LogError($"Failed to ping {server.Address}", ex);
            return null;
        }
    }

    public string BuildConnectionString(ServerEntry server)
    {
        return $"samp://{server.Address}:{server.Port}";
    }
}
