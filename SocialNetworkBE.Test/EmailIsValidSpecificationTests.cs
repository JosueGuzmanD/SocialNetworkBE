using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialNetworkBE.Test;

public class EmailIsValidSpecificationTests
{
    [Fact]
    public void IsSatisfiedBy_ReturnsSuccess_WhenEmailIsValid()
    {
        // Arrange
        var specification = new EmailIsValidSpecification();
        var dto = new CreatePlayerDto { Email = "validemail@example.com" };

        // Act
        var result = specification.IsSatisfiedBy(dto);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsFailure_WhenEmailIsInvalid()
    {
        // Arrange
        var specification = new EmailIsValidSpecification();
        var dto = new CreatePlayerDto { Email = "invalid-email" };

        // Act
        var result = specification.IsSatisfiedBy(dto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Invalid email format.", result.ErrorMessage);
    }

    [Xunit.Theory]
    [InlineData("validemail@gmail.com", true)]
    [InlineData("mail@outlook.com", true)]
    [InlineData("mail@hotmail.com", true)]
    [InlineData("mail@yahoo.com", true)]
    [InlineData("mail@gmail.es", true)]
    public void IsSatisfiedBy_ValidatesPrincipalMailProviders(string mail, bool expectedResult)
    {
        // Arrange
        var specification = new EmailIsValidSpecification();
        var dto = new CreatePlayerDto { Email = mail };

        // Act
        var result = specification.IsSatisfiedBy(dto);

        // Assert
        Assert.Equal(expectedResult, result.IsSuccess);
    }
}
