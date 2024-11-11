using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using Xunit;

public class UsernameFormatSpecificationTests
{
    [Fact]
    public void IsSatisfiedBy_ValidAlphanumericUsername_ReturnsTrue()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "ValidUser123" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSatisfiedBy_UsernameWithSpaces_ReturnsFalse()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "Invalid User" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSatisfiedBy_UsernameWithSpecialCharacters_ReturnsFalse()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "Invalid@User!" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSatisfiedBy_EmptyUsername_ReturnsFalse()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsSatisfiedBy_UsernameWithOnlyNumbers_ReturnsTrue()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "123456" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSatisfiedBy_ErrorMessageMatchesExpected()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();

        // Act
        var errorMessage = specification.ErrorMessage;

        // Assert
        Assert.Equal("Username must be alphanumeric without spaces or special characters.", errorMessage);
    }
}
