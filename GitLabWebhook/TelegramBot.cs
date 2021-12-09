using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace GitLabWebhook;

public class TelegramBot : ITelegramBot
{
    private readonly TelegramBotClient _bot;
    private readonly ILogger<TelegramBot> _logger;

    public TelegramBot(string token, ILogger<TelegramBot> logger)
    {
        _bot = new TelegramBotClient(token);
        _logger = logger;
    }

    public async Task Send(int chatId, string message)
    {
        _logger.LogInformation("Send message");
        await _bot.SendTextMessageAsync(chatId, message, ParseMode.Html, disableWebPagePreview: true);
    }
}