namespace TarefasApi.Middleware
{
    public sealed class RequestLoggingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleWare> _logger;

        public RequestLoggingMiddleWare(RequestDelegate next, ILogger<RequestLoggingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming Request: {method} {url}", context.Request.Method, context.Request.Path);
            context.Response.OnStarting(() =>
            {

                _logger.LogInformation("Outgoing Response: {statusCode}", context.Response.StatusCode);
                return Task.CompletedTask;
            });
           
            await _next(context);
        }
    }
}
