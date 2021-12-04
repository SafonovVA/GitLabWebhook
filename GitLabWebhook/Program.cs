using System.Net;
using GitLabWebhook;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionString("TelegramBotToken"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
});

var app = builder.Build();

app.MapControllers();


app.Run();
/*
* heroku container:login
* docker login --username=_ --password=$(heroku auth:token) safonovva
* docker build -t safonovva/safonovva-gitlab-webhook .
* docker push safonovva/safonovva-gitlab-webhook
* heroku container:push web --app safonovva-gitlab-webhook
* heroku container:release web --app safonovva-gitlab-webhook
*/