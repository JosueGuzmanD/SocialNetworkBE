using Microsoft.AspNetCore.Mvc;
using SocialNetworkBE.Application;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;

namespace SocialNetworkBE.Api.Controllers;

[ApiController]
[Route("api/player")]
public class PlayerController: ControllerBase
{
    
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost("register")]
    public async Task<Result<CreatePlayerDto>> RegisterPlayer([FromBody] CreatePlayerDto createPlayerDto,[FromQuery] string password)
    {
        if (!ModelState.IsValid) return Result<CreatePlayerDto>.Failure("ModelState is not valid");
       
        var result = await _playerService.RegisterPlayerAsync(createPlayerDto, password);

        if (!result.IsSuccess)
        {
            return Result<CreatePlayerDto>.Failure(result.ErrorMessage);
        }
        return result;
    }
    
}