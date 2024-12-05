using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Interfaces;

public interface IRoleService
{
    Task<Result<string>> AssignRoleAsync(ApplicationUser user, string role);
    Task<Result<string>> RemoveRoleAsync(ApplicationUser user, string roleName);
    Task<Result<IList<string>>> GetRolesAsync(ApplicationUser user);
    Task<Result<string>> CreateRoleAsync(string roleName);
}