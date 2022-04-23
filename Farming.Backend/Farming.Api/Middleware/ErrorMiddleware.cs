using Farming.Shared.Abstractions.Exceptions;
using Newtonsoft.Json;
using NLog;
using System.Net;

namespace Farming.Api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
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

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = farmingException.Message,
                    name = farmingException.GetType().Name
                }));
            }
            else
            {
                SaveErrorLog(context, exception, true);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name
                }));
            }
        }

        private void SaveErrorLog(HttpContext context, Exception exception, bool isUnhandled)
        {
            LogManager.GetLogger("default")
                .WithProperty("name", exception.GetType().Name)
                .WithProperty("createDate", DateTimeOffset.Now)
                .WithProperty("isUnhandled", isUnhandled)
                .Error(exception);
        }
    }
}
