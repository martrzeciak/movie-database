namespace MovieDatabase.Application.Common;

public abstract class Result
{
    public bool IsSuccess { get; set; }
    public string? Error { get; set; }
    public int Code { get; set; }
}

public class Result<T> : Result
{
    public T? Value { get; set; }

    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Failure(string error, int code) => new()
    {
        IsSuccess = false,
        Error = error,
        Code = code
    };
}