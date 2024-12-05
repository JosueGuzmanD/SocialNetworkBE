using Microsoft.AspNetCore.Mvc;
using SocialNetworkBE.Application;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Services;

namespace SocialNetworkBE.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RoleController: ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var result = _roleService.CreateRoleAsync(roleName);
        
        return Ok(result);
    }
    
    
}