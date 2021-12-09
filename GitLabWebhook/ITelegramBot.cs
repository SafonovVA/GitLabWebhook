namespace GitLabWebhook;

public interface ITelegramBot
{ 
    Task Send(int chatId, string message);
}