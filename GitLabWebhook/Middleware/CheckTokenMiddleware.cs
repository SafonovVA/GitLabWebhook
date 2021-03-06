using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GitLabWebhook.Middleware;

public class CheckTokenMiddleware
{
    private readonly ILogger<CheckTokenMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly string _token;

    public CheckTokenMiddleware(RequestDelegate next, ILogger<CheckTokenMiddleware> logger, string token)
    {
        _next = next;
        _logger = logger;
        _token = token;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string headerToken = context.Request.Headers["X-Gitlab-Token"];
        if (headerToken != _token)
        {
            _logger.LogWarning("Invalid token from: {Host}", context.Request.Host);
            await context.Response.WriteAsync("X-Gitlab-Token is invalid");
        }
        else
        {
            await _next(context);
        }
    }
}