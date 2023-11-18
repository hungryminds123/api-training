using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace TrainingAPI.Middleware;

public static class ExceptionHandlerMiddleware
{
    public static void ConfigureExceptionHandler(
        this IApplicationBuilder app)
       
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                if (contextFeature != null)
                {
                    // custom code to handle exception

                    var errorMessage = contextFeature.Error.Message;

                    await context.Response.WriteAsync(errorMessage);
                }
            });
        });
    }
}