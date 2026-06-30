namespace WebApplication;

public class Work : BackgroundService
{
    private readonly ILogger<Work> _logger;

    public Work(ILogger<Work> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogWarning("Тестовый лог от BackgroundService в Loki!");
        await Task.Delay(5000, stoppingToken);
    }
}