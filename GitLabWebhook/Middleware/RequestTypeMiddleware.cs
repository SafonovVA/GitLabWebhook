using System.Diagnostics;
using System.Text;

namespace GitLabWebhook.Middleware;

[Obsolete]
public class RequestTypeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTypeMiddleware> _logger;
    
    public RequestTypeMiddleware(RequestDelegate next, ILogger<RequestTypeMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Body.CanSeek)
        {
            context.Request.EnableBuffering();
        }
        context.Request.Body.Position = 0;
        
        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
        {
            var body = await reader.ReadToEndAsync().ConfigureAwait(false);
            _logger.LogError(body);
        }
        context.Request.Body.Position = 0;
        
        //context.Response.Redirect("/Push");
        
        await _next(context);
    }
}