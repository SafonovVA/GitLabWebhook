using System.Threading.Tasks;
using GitLabWebhook.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitLabWebhook.Controllers;

[ApiController]
[Area("api")]
[Route("[area]/gitlab")]
public class GitLabWebhookController : ControllerBase
{
    private readonly TelegramBot _bot;
    private readonly ILogger<GitLabWebhookController> _logger;

    public GitLabWebhookController(ILogger<GitLabWebhookController> logger, TelegramBot bot)
    {
        _logger = logger;
        _bot = bot;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Handle([FromBody] EventRequest eventRequest)
    {
        _logger.LogInformation("Request is come");
        var message = eventRequest.ToString();
        if (message != string.Empty)
        {
            await _bot.Send(-703603408, eventRequest.ToString());
        }
        return Ok(eventRequest);
    }
}