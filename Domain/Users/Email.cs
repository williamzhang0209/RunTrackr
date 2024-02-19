using Domain.Abstractions;

namespace Domain.Users;

public sealed record Email 
{
	private Email(string value)
	{
		Value= value;
	}
	public string Value { get;}

	//static factory method to create email
	//Return Result type
	public static Result<Email> Create(string? email)
	{
		Ensure.NotNullOrEmpty(email);

		if (email.Split('@').Length != 2) {
			throw new ApplicationException("Invalid Email");
		}
		return new Email(email);
	}
}
