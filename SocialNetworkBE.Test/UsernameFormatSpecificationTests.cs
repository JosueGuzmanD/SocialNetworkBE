using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using Xunit;
using Assert = Xunit.Assert;

public class UsernameFormatSpecificationTests
{
    [Fact]
    public void IsSatisfiedBy_ReturnsSuccess_WhenUsernameIsAlphanumeric()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "ValidUser123" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsFailure_WhenUsernameContainsSpaces()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "Invalid User" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Username must be alphanumeric without spaces or special characters.", result.ErrorMessage);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsFailure_WhenUsernameContainsSpecialCharacters()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "Invalid@User!" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Username must be alphanumeric without spaces or special characters.", result.ErrorMessage);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsFailure_WhenUsernameIsEmpty()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Username must be alphanumeric without spaces or special characters.", result.ErrorMessage);
    }

    [Fact]
    public void IsSatisfiedBy_ReturnsSuccess_WhenUsernameIsOnlyNumbers()
    {
        // Arrange
        var specification = new UsernameFormatSpecification();
        var playerDto = new CreatePlayerDto { Name = "123456" };

        // Act
        var result = specification.IsSatisfiedBy(playerDto);

        // Assert
        Assert.True(result.IsSuccess);
    }
}