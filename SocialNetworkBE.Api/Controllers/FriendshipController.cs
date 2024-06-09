using Microsoft.AspNetCore.Mvc;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FriendshipController : ControllerBase
{
    private readonly IFriendshipService _friendshipService;

    public FriendshipController(IFriendshipService friendshipService)
    {
        _friendshipService = friendshipService;
    }

    [HttpGet]
    [Route("getbyId")]
    public async Task<ActionResult<FriendshipDto>> GetById(Guid id)
    {
        try
        {
           var friendship= await _friendshipService.GetByIdAsync(id);
            return Ok(friendship);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }

    [HttpPost]
    [Route("sendRequest")]
    public async Task<IActionResult> SendFriendshipRequest([FromBody] FriendshipRequestDto friendshipDto)
    {
        try
        {
            await _friendshipService.sendFriendshipRequest(friendshipDto);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    [Route("updateStatus")]
    public async Task<IActionResult> UpdateFriendshipStatus(Guid id, [FromBody] FriendshipStatus newStatus)
    {
        try
        {
            await _friendshipService.UpdateFriendshipStatus(id, newStatus);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _friendshipService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


}
