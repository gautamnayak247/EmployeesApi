using ABB.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ABB.Api.Middlewares
{
    public class ContentNegotiationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IABBLogger logger;
        public ContentNegotiationMiddleware(RequestDelegate _next, IABBLogger _loggger)
        {
            next = _next;
            logger = _loggger ?? throw new ArgumentNullException(nameof(logger));

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var acceptHeader = httpContext.Request.Headers.ContainsKey("Accept") ?
                            httpContext.Request.Headers["Accept"].ToString() :
                            string.Empty;
            if ("application/json".Equals(acceptHeader))
            {
                await next(httpContext);
            }
            else
            {
                await HandleNotAcceptableAsync(httpContext).ConfigureAwait(false);
            }
        }

        private async Task HandleNotAcceptableAsync(HttpContext context)
        {
            logger.LogInformation(nameof(ContentNegotiationMiddleware), nameof(HandleNotAcceptableAsync), "Accept header is missing or not allowed");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            await context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
            }.ToString()).ConfigureAwait(false);
        }
    }
}
