using Microsoft.AspNetCore.Mvc;

namespace GitLabWebhook.Controllers;

[ApiController]
public class GitLabWebhookController : ControllerBase
{
    private readonly ILogger<GitLabWebhookController> _logger;
    private readonly TelegramBot _bot;

    public GitLabWebhookController(ILogger<GitLabWebhookController> logger, TelegramBot bot)
    {
        _logger = logger;
        _bot = bot;
    }
    
    [Route("")]
    public void Get()
    {
        _logger.LogInformation("Request is come");
        _bot.Send();
    }
}