using GitLabWebhook;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionString("TelegramBotToken"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

var app = builder.Build();

app.MapControllers();

app.Run();