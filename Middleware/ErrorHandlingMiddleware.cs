using System.Net;
using Microsoft.AspNetCore.Http;

namespace TarefasApi.Middleware
{
    public sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)=> _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
               context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync( new 
                { 
                    status = 404,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync( new 
                { 
                    status = 500,
                    message = "Ocorreu um erro interno no servidor."
                });
            }
        }

    }
}
