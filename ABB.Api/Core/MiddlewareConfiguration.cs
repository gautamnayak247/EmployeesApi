using ABB.Api.Middlewares;
using ABB.Domain;
using Microsoft.AspNetCore.Builder;
using System;

namespace ABB.Api.Core
{
    public static class MiddlewareConfiguration
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionMiddleware>();

        public static void UseTraceIdentifier(this IApplicationBuilder app)
            => app.Use(async (context, next) =>
            {
                context.TraceIdentifier = Guid.NewGuid().ToString();
                context.Response.Headers.Add(Constant.TraceIdHeader, context.TraceIdentifier);
                await next();
            });
        public static void UseNotAcceptableMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ContentNegotiationMiddleware>();
    }
}
