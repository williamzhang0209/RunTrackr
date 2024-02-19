using Domain.Users;
using FluentAssertions;

namespace Domain.UnitTests.Users
{
    public class NameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_ThrowArgumentException_WhenVauleisInvalid(string? value1)
        {
            Name Action() => new(value1);

            //Assert
            FluentActions.Invoking(Action).Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("value");
        }
    }
}