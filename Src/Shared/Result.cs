namespace NukeLogin.Src.Shared;
public class Result<T>
{
    public T? Value { get; }
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }

    private Result(bool isSuccess, T? value, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Value = value;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string message) => new(false, default, message);
}


