using Microsoft.AspNetCore.Identity;
using Moq;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Services;
using SocialNetworkBE.Domain.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace SocialNetworkBE.Test;

public class RoleServiceTests
{
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
    private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
    private readonly RoleService _roleService;

    public RoleServiceTests()
    {
        _userManagerMock = MockHelpers.MockUserManager<ApplicationUser>();
        _roleManagerMock = MockHelpers.MockRoleManager<IdentityRole>();
        _roleService = new RoleService(_userManagerMock.Object, _roleManagerMock.Object);
    }

    [Fact]
    public async Task CreateRoleAsync_ShouldReturnSuccess_WhenRoleCreated()
    {
        // Arrange
        var roleName = "Admin";
        _roleManagerMock.Setup(r => r.CreateAsync(It.IsAny<IdentityRole>()))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _roleService.CreateRoleAsync(roleName);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(roleName, result.Value);
    }

    [Fact]
    public async Task CreateRoleAsync_ShouldReturnFailure_WhenRoleCreationFails()
    {
        // Arrange
        var roleName = "Admin";
        _roleManagerMock.Setup(r => r.CreateAsync(It.IsAny<IdentityRole>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Creation failed" }));

        // Act
        var result = await _roleService.CreateRoleAsync(roleName);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Role creation failed", result.ErrorMessage);
    }

    [Fact]
    public async Task AssignRoleAsync_ShouldReturnSuccess_WhenRoleAssigned()
    {
        // Arrange
        var userId = "user123";
        var roleName = "Admin";
        var user = new ApplicationUser { Id = userId };
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);
        _userManagerMock.Setup(u => u.AddToRoleAsync(user, roleName))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _roleService.AssignRoleAsync(new AssignRoleDto { PlayerId = userId, RoleName = roleName });

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Successfully assigned role", result.Value);
    }

    [Fact]
    public async Task AssignRoleAsync_ShouldReturnFailure_WhenUserNotFound()
    {
        // Arrange
        var userId = "user123";
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _roleService.AssignRoleAsync(new AssignRoleDto { PlayerId = userId, RoleName = "Admin" });

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("User not found", result.ErrorMessage);
    }

    [Fact]
    public async Task RemoveRoleAsync_ShouldReturnSuccess_WhenRoleRemoved()
    {
        // Arrange
        var userId = "user123";
        var roleName = "Admin";
        var user = new ApplicationUser { Id = userId };
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);
        _userManagerMock.Setup(u => u.RemoveFromRoleAsync(user, roleName))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _roleService.RemoveRoleAsync(new AssignRoleDto { PlayerId = userId, RoleName = roleName });

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Successfully removed role", result.Value);
    }

    [Fact]
    public async Task RemoveRoleAsync_ShouldReturnFailure_WhenRoleRemovalFails()
    {
        // Arrange
        var userId = "user123";
        var roleName = "Admin";
        var user = new ApplicationUser { Id = userId };
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);
        _userManagerMock.Setup(u => u.RemoveFromRoleAsync(user, roleName))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Removal failed" }));

        // Act
        var result = await _roleService.RemoveRoleAsync(new AssignRoleDto { PlayerId = userId, RoleName = roleName });

        // Assert
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task GetRolesAsync_ShouldReturnRoles_WhenUserHasRoles()
    {
        // Arrange
        var userId = "user123";
        var roles = new List<string> { "Admin", "User" };
        var user = new ApplicationUser { Id = userId };
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);
        _userManagerMock.Setup(u => u.GetRolesAsync(user)).ReturnsAsync(roles);

        // Act
        var result = await _roleService.GetRolesAsync(userId);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(roles, result.Value);
    }

    [Fact]
    public async Task GetRolesAsync_ShouldReturnFailure_WhenUserNotFound()
    {
        // Arrange
        var userId = "user123";
        _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync((ApplicationUser)null);

        // Act
        var result = await _roleService.GetRolesAsync(userId);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("User not found", result.ErrorMessage);
    }
}