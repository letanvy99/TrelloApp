using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Trello.Service.Exceptions;

namespace Trello.API.Middlewares
{
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HandleExceptionMiddleware> _logger;

        public HandleExceptionMiddleware(RequestDelegate next, ILogger<HandleExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var message = exception.Message;

            if (exception.GetType() == typeof(UserNotFoundException))
            {
                message = "User is deactived.";
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (exception.GetType() == typeof(BadRequestException))
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            else if (exception.GetType() == typeof(ForbidenException))
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            else
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(JsonSerializer.Serialize(message));

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandleExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleExceptionMiddleware>();
        }
    }
}