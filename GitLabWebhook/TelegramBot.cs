using Telegram.Bot;

namespace GitLabWebhook;

public class TelegramBot : ITelegramBot
{
    private readonly ILogger<TelegramBot> _logger;
    private readonly TelegramBotClient _bot;

    public TelegramBot(string token, ILogger<TelegramBot> logger)
    {
        _bot = new TelegramBotClient(token);
        _logger = logger;
    }
    public async Task Send()
    {
        _logger.LogInformation("Send message");
        await _bot.SendTextMessageAsync(-703603408, "SUKA");
    }
}