using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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

    public async Task Send(int chatId, string message)
    {
        _logger.LogInformation("Send message");
        await _bot.SendTextMessageAsync(chatId, message, ParseMode.Html);
    }
}