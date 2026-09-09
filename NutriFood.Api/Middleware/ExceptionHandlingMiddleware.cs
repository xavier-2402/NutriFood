using System.Net;
using System.Text.Json;
using NutriFood.Api.Contracts;

namespace NutriFood.Api.Middleware;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred while processing the request.");

            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var response = ResponseResult<object?>.Failure(statusCode, "An unexpected error occurred while processing the request.");

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
    }
}