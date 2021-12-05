using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using TeamProject.Domain.Exceptions;

namespace TeamProject.Application.Middlewares;

internal class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (HttpException httpException)
        {
            _logger.LogError(httpException, httpException.GetType().ToString());
            context.Response.StatusCode = httpException.StatusCode;
            var responseFeature = context.Features.Get<IHttpResponseFeature>();
            responseFeature.ReasonPhrase = httpException.Message;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.GetType().ToString());
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var responseFeature = context.Features.Get<IHttpResponseFeature>();
            responseFeature.ReasonPhrase = exception.Message;
        }
    }
}