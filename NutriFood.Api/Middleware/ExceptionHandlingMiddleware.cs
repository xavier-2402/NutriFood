using System.Net;
using System.Text.Json;
using FluentValidation;
using NutriFood.Api.Contracts;
using NutriFood.Application.Common.Exceptions;

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
        catch (NotFoundException exception)
        {
            _logger.LogWarning(exception, "A requested resource was not found.");

            await HandleNotFoundExceptionAsync(context, exception);
        }
        catch (ValidationException exception)
        {
            _logger.LogWarning(exception, "A validation error occurred while processing the request.");

            await HandleValidationExceptionAsync(context, exception);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occurred while processing the request.");

            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        var statusCode = (int)HttpStatusCode.BadRequest;
        var message = string.Join(" ", exception.Errors.Select(e => e.ErrorMessage));
        var response = ResponseResult<object?>.Failure(statusCode, message);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
    }

    private static async Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException exception)
    {
        var statusCode = (int)HttpStatusCode.NotFound;
        var response = ResponseResult<object?>.Failure(statusCode, exception.Message);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions(JsonSerializerDefaults.Web)));
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
