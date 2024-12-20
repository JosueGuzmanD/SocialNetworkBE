using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Extensions;
using SocialNetworkBE.Application.Interfaces;

namespace SocialNetworkBE.Api.Controllers;

[ApiController]
[Route("api/player")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterPlayer([FromBody] CreatePlayerDto createPlayerDto, [FromQuery] string password)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("ModelState is not valid");
        }

        var result = await _playerService.RegisterPlayerAsync(createPlayerDto, password);
        return result.ToActionResult(); 
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _playerService.GetAllPlayersAsync();
        return result.ToActionResult();
    }
    
}