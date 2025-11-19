using Launcher.Core.Services.Interfaces;

namespace Launcher.Core.Services;

public sealed class FileLogService : ILogService
{
    private readonly string _logDirectory;
    private readonly object _sync = new();

    public event EventHandler<string>? MessageLogged;

    public FileLogService(string logDirectory)
    {
        _logDirectory = logDirectory;
        Directory.CreateDirectory(_logDirectory);
    }

    public void LogInformation(string message)
    {
        Write("INFO", message);
    }

    public void LogError(string message, Exception? exception = null)
    {
        Write("ERROR", exception is null ? message : $"{message}: {exception.Message}");
    }

    private void Write(string level, string message)
    {
        var logLine = $"[{DateTime.UtcNow:O}] {level}: {message}";
        lock (_sync)
        {
            var logPath = Path.Combine(_logDirectory, $"launcher-{DateTime.UtcNow:yyyyMMdd}.log");
            File.AppendAllText(logPath, logLine + Environment.NewLine);
        }

        MessageLogged?.Invoke(this, logLine);
    }
}
