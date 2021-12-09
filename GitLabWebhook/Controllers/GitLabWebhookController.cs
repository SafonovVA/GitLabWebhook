using GitLabWebhook.Requests;
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
    
    [HttpPost, Route("")]
    public async Task<IActionResult> Get([FromBody] EventRequest eventRequest)
    {
        _logger.LogInformation("Request is come");
        // TODO: make chat ID dynamically, need web page to manage chat -> project
        await _bot.Send(-703603408, eventRequest.ToString());
        return Ok(eventRequest);
    }
}









