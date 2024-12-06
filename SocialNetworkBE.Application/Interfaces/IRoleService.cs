using SocialNetworkBE.Application.DTOs;

namespace SocialNetworkBE.Application.Interfaces;

public interface IRoleService
{
    Task<Result<string>> CreateRoleAsync(string roleName);
    Task<Result<string>> AssignRoleAsync(AssignRoleDto assignRoleDto);
    Task<Result<string>> RemoveRoleAsync(AssignRoleDto assignRoleDto);
    Task<Result<IList<string>>> GetRolesAsync(string playerId);
}