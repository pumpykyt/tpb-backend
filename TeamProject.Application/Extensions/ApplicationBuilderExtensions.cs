using Microsoft.AspNetCore.Builder;
using TeamProject.Application.Middlewares;

namespace TeamProject.Application.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseHttpException(this IApplicationBuilder application)
    {
        return application.UseMiddleware<ErrorHandlerMiddleware>();
    }
}