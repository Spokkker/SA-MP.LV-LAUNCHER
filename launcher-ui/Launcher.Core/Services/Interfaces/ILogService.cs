namespace Launcher.Core.Services.Interfaces;

public interface ILogService
{
    void LogInformation(string message);
    void LogError(string message, Exception? exception = null);
    event EventHandler<string>? MessageLogged;
}
