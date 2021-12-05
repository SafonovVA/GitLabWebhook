using System.Net;
using GitLabWebhook;
//https://safonovva-gitlab-webhook.herokuapp.com/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionString("TelegramBotToken"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

/*builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
});*/

var app = builder.Build();

app.MapControllers();


app.Run();