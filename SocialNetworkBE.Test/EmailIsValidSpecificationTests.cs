using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace SocialNetworkBE.Test;

public class EmailIsValidSpecificationTests
{
    [Fact]
    public void IsSatisfiedBy_ReturnsTrue_WhenEmailIsValid()
    {
        // Arrange
        var specification = new EmailIsValidSpecification();
        var dto = new CreatePlayerDto { Email = "validemail@example.com" };

        // Act
        var result = specification.IsSatisfiedBy(dto);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsFalse_WhenEmailIsInvalid()
    {
        // Arrange
        var specification = new EmailIsValidSpecification();
        var dto = new CreatePlayerDto { Email = "invalid-email" };

        // Act
        var result = specification.IsSatisfiedBy(dto);

        // Assert
        Assert.False(result);
    }
}