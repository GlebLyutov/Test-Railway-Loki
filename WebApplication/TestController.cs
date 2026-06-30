using Microsoft.AspNetCore.Mvc;

namespace WebApplication;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("log-test")]
    public IActionResult TriggerLogs()
    {
        _logger.LogInformation("Запрос на log-test успешно обработан.");
        _logger.LogWarning("Тестовое предупреждение для проверки Grafana. Действие выполнено в {Time}",
            DateTime.UtcNow);

        try
        {
            throw new InvalidOperationException("Тестовое исключение для проверки мониторинга.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "В контроллере произошла ожидаемая тестовая ошибка.");
        }

        return Ok(new { message = "Логи отправлены в Loki! Проверяйте Grafana." });
    }
}