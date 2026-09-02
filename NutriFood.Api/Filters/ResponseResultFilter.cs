using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NutriFood.Api.Contracts;

namespace NutriFood.Api.Filters;

public sealed class ResponseResultFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult { Value: ResponseResult<object?> })
        {
            await next();
            return;
        }

        context.Result = context.Result switch
        {
            NoContentResult => new ObjectResult(ResponseResult<object?>.Ok(null, "Operation completed successfully."))
            {
                StatusCode = StatusCodes.Status200OK
            },
            StatusCodeResult { StatusCode: var status } => new ObjectResult(ResponseResult<object?>.Failure(status, GetMessage(status)))
            {
                StatusCode = status
            },
            ObjectResult { Value: var value, StatusCode: var statusCode } => CreateObjectResult(value, statusCode ?? StatusCodes.Status200OK),
            _ => context.Result
        };

        await next();
    }

    private static ObjectResult CreateObjectResult(object? value, int status)
    {
        var result = status >= StatusCodes.Status400BadRequest
            ? ResponseResult<object?>.Failure(value, status, GetMessage(status))
            : status == StatusCodes.Status201Created
                ? ResponseResult<object?>.Created(value)
                : ResponseResult<object?>.Ok(value);

        return new ObjectResult(result) { StatusCode = status };
    }

    private static string GetMessage(int status) => status switch
    {
        StatusCodes.Status400BadRequest => "The request is invalid.",
        StatusCodes.Status404NotFound => "The requested resource was not found.",
        StatusCodes.Status409Conflict => "The request conflicts with the current resource state.",
        _ => "The request could not be completed."
    };
}
