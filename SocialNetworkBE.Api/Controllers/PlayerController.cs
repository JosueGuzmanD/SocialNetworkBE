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
    public async Task<IActionResult> RegisterPlayer(string password,CreatePlayerDto createPlayerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("ModelState is not valid");
        }

        var result = await _playerService.RegisterPlayerAsync(createPlayerDto, password);
        return result.ToActionResult(); 
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("getAllPlayers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _playerService.GetAllPlayersAsync();
        return result.ToActionResult();
    }

    [HttpGet("GetPlayerById/{id}")]
    public async Task<ActionResult<PlayerDto>> GetPlayerById(Guid id)
    {
        var result = await _playerService.GetPlayerByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("GetTopScorers/{limit}")]
    public async Task<ActionResult<PlayerDto>> GetTopScorers(int limit)
    {
        var result= await _playerService.GetTopScorersAsync(limit);
        
        return Ok(result);
    }

    [HttpGet("SearchPlayers")]
    public async Task<ActionResult<PlayerDto>> SearchPlayersAsync([FromQuery] PlayerQueryDto playerQueryDto)
    {
        var result= await _playerService.SearchPlayersAsync(playerQueryDto);
        return Ok(result);
    }

    [HttpPut("UpdatePlayer/{id}")]
    public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        var result= await _playerService.UpdatePlayerAsync(id, updatePlayerDto);
        
        return result.ToActionResult();
    }
    
    
}