using GitLabWebhook.Models;
using GitLabWebhook.Requests.Requests;
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
    
    [HttpGet, Route("")]
    public async Task<IActionResult> Get([FromBody] EventRequest eventRequest)
    {
        _logger.LogInformation("Request is come");
        await _bot.Send();
        return Ok(eventRequest);
    }
    
    [HttpPost]
    [Route("persons")]
    public List<Person> Add([FromBody]List<Person> people)
    {
        return people;
    }
    
    [HttpPost]
    [Route("person")]
    public Person Add([FromBody] Person people)
    {
        return people;
    }
}









