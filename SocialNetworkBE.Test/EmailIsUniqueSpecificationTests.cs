using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Test;

using Moq;
using System.Threading.Tasks;
using Xunit;

public class EmailIsUniqueSpecificationTests
{
    [Fact]
    public async Task IsSatisfiedByAsync_ReturnsSuccess_WhenEmailIsUnique()
    {
        // Arrange
        var playerRepositoryMock = new Mock<IPlayerRepository>();
        playerRepositoryMock.Setup(repo => repo.GetPlayerByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((Player)null);

        var specification = new EmailIsUniqueSpecification(playerRepositoryMock.Object);
        var dto = new CreatePlayerDto { Email = "unique@example.com" };

        // Act
        var result = await specification.IsSatisfiedByAsync(dto);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task IsSatisfiedByAsync_ReturnsFailure_WhenEmailIsNotUnique()
    {
        // Arrange
        var playerRepositoryMock = new Mock<IPlayerRepository>();
        playerRepositoryMock.Setup(repo => repo.GetPlayerByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new Player());

        var specification = new EmailIsUniqueSpecification(playerRepositoryMock.Object);
        var dto = new CreatePlayerDto { Email = "existing@example.com" };

        // Act
        var result = await specification.IsSatisfiedByAsync(dto);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("The email is already in use.", result.ErrorMessage);
    }
}
