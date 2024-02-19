using Domain.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace Domain.UnitTests.Domain;

public class DomainTests
{
    private static readonly Assembly DomainAssembly= typeof(Entity).Assembly;

    [Fact]
    public void DomainEvents_Should_BeSealed()
    { 
        var result = Types.InAssembly(DomainAssembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}

