using GitLabWebhook;
using GitLabWebhook.Middleware;

//https://safonovva-gitlab-webhook.herokuapp.com/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionString("TelegramBotToken"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

builder.WebHost.UseSentry(o =>
{
    o.Dsn = builder.Configuration.GetConnectionString("SentryDsn");
    o.Debug = true;
    o.TracesSampleRate = 1.0;
});

var app = builder.Build();

app.UseMiddleware<CheckTokenMiddleware>(builder.Configuration.GetConnectionString("GitlabToken"));

app.MapControllers();

app.Run();