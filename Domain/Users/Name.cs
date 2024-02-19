namespace Domain.Users;

//recors as Value Object. Immutable
public sealed record Name 
{
	public Name(string? value)
	{       
        if (string.IsNullOrEmpty(value))
		{
			//throw new ArgumentNullException(nameof(value));
			Ensure.NotNullOrEmpty(value);

			Value = value;
		}
	}

	public string Value { get; }
}
