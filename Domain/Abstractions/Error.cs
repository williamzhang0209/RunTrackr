namespace Domain.Abstractions;

////Exception VS Result Pattern
//public sealed class CantFollowYourselfException : Exception 
//{
//    public CantFollowYourselfException()
//        :base("Can't follow yourself")
//    {

//    }
//}

public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new Error(string.Empty);
    public static readonly Error NullValue = new Error("Error.NullValue", "Null Value provided");
    public static implicit operator Result(Error error) => Result.Failure(error);
}
