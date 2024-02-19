using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users;

//User class is Entity
public sealed class User : Entity
{
	private User(Guid id, Email email, Name name, bool hasPublicProfile)
		:base(id)
	{
		Email= email;
		Name= name;
		HasPublicProfile= hasPublicProfile;
	}
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public bool HasPublicProfile { get; set; }
	//static method to create user entity.
	//have more control to create user entity
	//Static Factory Pattern
	//updated
	public static User Create(Email email, Name name, bool hasPublicProfile)
	{
		var user = new User(Guid.NewGuid(), email, name, hasPublicProfile);

		user.Raise(new UserCreatedDomainEvent(user.Id));

		return user;
	}
}
