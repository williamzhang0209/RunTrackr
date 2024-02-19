using Domain.Followers;
using Domain.Users;

namespace Domain.UnitTests.Followers;

public class FollowerServiceTests
{
    [Fact]
    public async Task StartFollowingAsync_Should_ReturnError_WhenFollowingSameUser()
    {
        //Arrange
        var followService = new FollowerService(null);
       //var email = Email.Create()
        //Act

        //Assert
    }
}
