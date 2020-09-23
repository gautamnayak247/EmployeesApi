using ABB.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ABB.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IABBLogger logger;
        public ExceptionMiddleware(RequestDelegate _next, IABBLogger _logger)
        {
            next = _next;
            logger = _logger ?? throw new ArgumentNullException(nameof(ExceptionMiddleware));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(ExceptionMiddleware), "GlobalException", ex.Message ?? ex.InnerException.Message, ex);
                await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string message;
            if (exception is UnprocessableException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                message = exception.Message;
            }
            else if (exception is AccessForbiddenException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                message = exception.Message;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                message = Constant.GlobalErrorMessage;
            }
            var response = Activator.CreateInstance<Error>();
            response.StatusCode = context.Response.StatusCode;
            response.Message = message;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
