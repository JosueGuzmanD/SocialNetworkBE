using Microsoft.AspNetCore.Mvc;
using SocialNetworkBE.Application;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Extensions;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Services;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromQuery] string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("Role name cannot be empty.");
        var result = await _roleService.CreateRoleAsync(roleName);

        return result.ToActionResult();
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto assignRoleDto)
    {
        if (assignRoleDto == null || string.IsNullOrWhiteSpace(assignRoleDto.PlayerId) ||
            string.IsNullOrWhiteSpace(assignRoleDto.RoleName)) return BadRequest("Invalid input.");

        var result = await _roleService.AssignRoleAsync(assignRoleDto);
        return result.ToActionResult();
    }

    [HttpPost("remove")]
    public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto assignRoleDto)
    {
        if (assignRoleDto == null || string.IsNullOrWhiteSpace(assignRoleDto.PlayerId) ||
            string.IsNullOrWhiteSpace(assignRoleDto.RoleName)) return BadRequest("Invalid input.");

        var result = await _roleService.RemoveRoleAsync(assignRoleDto);
        return result.ToActionResult();
    }

    [HttpGet("roles/{userId}")]
    public async Task<IActionResult> GetRoles([FromRoute] string userId)
    {
        if (string.IsNullOrWhiteSpace(userId)) return BadRequest("User ID cannot be empty.");

        var result = await _roleService.GetRolesAsync(userId);
        return result.ToActionResult();
    }
}