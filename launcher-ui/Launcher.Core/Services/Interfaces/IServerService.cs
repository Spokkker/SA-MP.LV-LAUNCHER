using Launcher.Core.Models;

namespace Launcher.Core.Services.Interfaces;

public interface IServerService
{
    Task<IReadOnlyCollection<ServerEntry>> GetServersAsync(AppConfiguration configuration, CancellationToken cancellationToken = default);
    Task<int?> PingServerAsync(ServerEntry server, CancellationToken cancellationToken = default);
    string BuildConnectionString(ServerEntry server);
}
