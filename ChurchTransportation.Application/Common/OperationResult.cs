namespace ChurchTransportation.Application.Common;

public sealed record OperationResult
{
    private OperationResult(bool succeeded, string? errorCode, string? errorMessage)
    {
        Succeeded = succeeded;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public bool Succeeded { get; }

    public bool Failed => !Succeeded;

    public string? ErrorCode { get; }

    public string? ErrorMessage { get; }

    public static OperationResult Success() => new(true, null, null);

    public static OperationResult Failure(string errorCode, string? errorMessage = null) =>
        new(false, errorCode, errorMessage);
}

public sealed record OperationResult<T>
{
    private OperationResult(bool succeeded, T? value, string? errorCode, string? errorMessage)
    {
        Succeeded = succeeded;
        Value = value;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    public bool Succeeded { get; }

    public bool Failed => !Succeeded;

    public T? Value { get; }

    public string? ErrorCode { get; }

    public string? ErrorMessage { get; }

    public static OperationResult<T> Success(T value) => new(true, value, null, null);

    public static OperationResult<T> Failure(string errorCode, string? errorMessage = null) =>
        new(false, default, errorCode, errorMessage);
}
