using Microsoft.AspNetCore.Identity;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Services;

public class RoleService : IRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RoleService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string>> AssignRoleAsync(ApplicationUser user, string role)
    {
        var result = await _userManager.AddToRoleAsync(user, role);

        return result.Succeeded
            ? Result<string>.Success("Successfully assigned role")
            : Result<string>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<Result<string>> RemoveRoleAsync(ApplicationUser user, string roleName)
    {
        var result = await _userManager.RemoveFromRoleAsync(user, roleName);

        return result.Succeeded
            ? Result<string>.Success("Successfully removed role")
            : Result<string>.Failure(string.Join(", ", result.Errors.Select(e => e.Description)));
    }

    public async Task<Result<IList<string>>> GetRolesAsync(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        if (roles == null || !roles.Any()) return Result<IList<string>>.Failure("No roles found");

        return Result<IList<string>>.Success(roles.ToList());
    }
}