using EagleBank.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EagleBank.Api.Extensions;

public static class ErrorHandling
{
    public static void UseErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                context.Response.ContentType = "application/text";

                switch (exception)
                {
                    case NotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case BadRequestException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case UnauthorizedException:
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                await context.Response.WriteAsync(exception?.Message ?? "An error occurred.");
            });
        });
    }
}