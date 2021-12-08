using GitLabWebhook;
using GitLabWebhook.Middleware;

//https://safonovva-gitlab-webhook.herokuapp.com/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionString("TelegramBotToken"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

var app = builder.Build();

app.UseMiddleware<CheckTokenMiddleware>(builder.Configuration.GetConnectionString("GitlabToken"));

app.MapControllers();

app.Run();