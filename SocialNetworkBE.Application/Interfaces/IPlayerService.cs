using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Application.Interfaces;

public interface IPlayerService
{
    Task<Result<CreatePlayerDto>> RegisterPlayerAsync(CreatePlayerDto createPlayerDto, string password);
    Task<Result<List<CreatePlayerDto>>> GetAllPlayersAsync();
    Task<Result<PlayerDto>> GetPlayerByIdAsync(Guid id);
    Task<Result<List<PlayerDto>>> GetTopScorersAsync(int limit);
    Task<Result<PlayerDto>> UpdatePlayerAsync(Guid playerId, UpdatePlayerDto updatePlayerDto);

    //TeamId,Position,Email,Name...
    Task<Result<List<PlayerDto>>> SearchPlayersAsync(PlayerQueryDto query);
}