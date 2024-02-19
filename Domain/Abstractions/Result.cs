using System.Net.Http.Headers;

namespace Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error= error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure { get; }
    public Error Error { get; }

 

    public static Result Success()
    {
        var res = new Result(true, Error.None);
        return res;
    }

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TVaule> Success<TVaule>(TVaule value) => new(value, true, Error.None);

    public static Result<TVaule> Failure<TVaule>(Error error) => new(default, false, error);
    
}


public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        :base(isSuccess, error)
    {
        _value= value;
    }
    public TValue? ValueE => IsSuccess 
        ? _value! 
        : throw new InvalidOperationException("The value of the failuere result can't be accessed");

    public static implicit operator Result<TValue>(TValue? value) => 
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
}