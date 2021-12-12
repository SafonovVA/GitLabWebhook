using GitLabWebhook;
using GitLabWebhook.Data;
using GitLabWebhook.Extensions;
using GitLabWebhook.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//https://safonovva-gitlab-webhook.herokuapp.com/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionStringFromEnvironment("DATABASE_CREDENTIALS")));

builder.Services.AddSingleton(bot => new TelegramBot(
    builder.Configuration.GetConnectionStringFromEnvironment("TELEGRAM_BOT_TOKEN"),
    bot.GetRequiredService<ILogger<TelegramBot>>()));

builder.WebHost.UseSentry(o =>
{
    o.Dsn = builder.Configuration.GetConnectionStringFromEnvironment("SENTRY_DSN");
    o.Debug = true;
    o.TracesSampleRate = 1.0;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapWhen(
    context => context.Request.Path.StartsWithSegments("/api/gitlab/"), 
    appBuilder => appBuilder.UseMiddleware<CheckTokenMiddleware>(builder.Configuration.GetConnectionStringFromEnvironment("GITLAB_TOKEN")));

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "gitlab",
    "api/gitlab",
    new { controller = "GitLabWebhookController", action = "Handle" });

app.MapRazorPages();

app.Run();