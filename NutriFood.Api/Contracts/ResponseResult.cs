namespace NutriFood.Api.Contracts;

public sealed class ResponseResult<T>
{
    public int Status { get; init; }
    public bool Success { get; init; }
    public string? Message { get; init; }
    public T? Data { get; init; }

    private ResponseResult(T? data, int status, bool success, string? message)
    {
        Data = data;
        Status = status;
        Success = success;
        Message = message;
    }

    public static ResponseResult<T> Ok(T data, string? message = null) => new(data, StatusCodes.Status200OK, true, message);

    public static ResponseResult<T> Created(T data, string? message = null) => new(data, StatusCodes.Status201Created, true, message);

    public static ResponseResult<T> Failure(int status, string message) => new(default, status, false, message);

    public static ResponseResult<T> Failure(T? data, int status, string message) => new(data, status, false, message);
}
