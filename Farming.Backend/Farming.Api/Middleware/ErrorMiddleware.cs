using Farming.Api.Auth;
using Farming.Application.Exceptions;
using Farming.Shared.Abstractions.Exceptions;
using FluentValidation;
using Newtonsoft.Json;
using NLog;
using System.Net;

namespace Farming.Api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";


            if (exception is FarmingException farmingException)
            {
                SaveErrorLog(context, exception, false);

                if (farmingException is AuthorizationException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }

                var commandValidationException = false;

                if (farmingException is ValidateCommandException)
                {
                    commandValidationException = true;
                }

                return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = farmingException.Message,
                    name = farmingException.GetType().Name,
                    commandValidationException = commandValidationException
                }));
            }
            else
            {
                SaveErrorLog(context, exception, true);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name,
                }));
            }
        }

        private void SaveErrorLog(HttpContext context, Exception exception, bool isUnhandled)
        {
            LogManager.GetLogger("default")
                .WithProperty("name", exception.GetType().Name)
                .WithProperty("createDate", DateTimeOffset.UtcNow)
                .WithProperty("isUnhandled", isUnhandled)
                .Error(exception);
        }
    }
}
