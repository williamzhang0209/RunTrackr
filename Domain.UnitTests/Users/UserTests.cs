

using Domain.Users;
using FluentAssertions;

namespace Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void Create_Should_ReturnUser_WhenNameisInvalid()
    {
        //Arrange
        var name = new Name("Full name");
        var email = Email.Create("test@123.com").ValueE;
        var hasPublicProfile = true;
        //Act
        var user = User.Create(email, name, hasPublicProfile);

        //Assert
        user.Should().NotBeNull();  
    }

    [Fact]
    public void Create_Should_RaiseDomainEvent_WhenNameisInvalid()
    {
        //Arrange
        var name = new Name("Full name");
        var email = Email.Create("test@123.com").ValueE;
        var hasPublicProfile = true;
        //Act
        var user = User.Create(email, name, hasPublicProfile);

        //Assert
        user.DomainEvents.Should().ContainSingle()
            .Which.Should().BeOfType<UserCreatedDomainEvent>();
    }
}

