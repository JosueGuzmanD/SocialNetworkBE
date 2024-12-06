using Microsoft.AspNetCore.Identity;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Services;

public class RoleService : IRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }


    public async Task<Result<string>> CreateRoleAsync(string roleName)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

        return result.Succeeded
            ? Result<string>.Success(roleName)
            : Result<string>.Failure("Role creation failed");
    }

    public async Task<Result<string>> AssignRoleAsync(AssignRoleDto assignRoleDto)
    {
        var user = await _userManager.FindByIdAsync(assignRoleDto.PlayerId);
        if (user == null) return Result<string>.Failure("User not found");

        var result = await _userManager.AddToRoleAsync(user, assignRoleDto.RoleName);
        return result.Succeeded
            ? Result<string>.Success("Successfully assigned role")
            : Result<string>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<Result<string>> RemoveRoleAsync(AssignRoleDto assignRoleDto)
    {
        var user = await _userManager.FindByIdAsync(assignRoleDto.PlayerId);
        if (user == null) return Result<string>.Failure("User not found");

        var result = await _userManager.RemoveFromRoleAsync(user, assignRoleDto.RoleName);
        return result.Succeeded
            ? Result<string>.Success("Successfully removed role")
            : Result<string>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<Result<IList<string>>> GetRolesAsync(string playerId)
    {
        var user = await _userManager.FindByIdAsync(playerId);
        if (user == null) return Result<IList<string>>.Failure("User not found");

        var roles = await _userManager.GetRolesAsync(user);

        return roles.Any()
            ? Result<IList<string>>.Success(roles)
            : Result<IList<string>>.Failure("No roles found for this user");
    }
}