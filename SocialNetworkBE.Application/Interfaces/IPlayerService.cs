using SocialNetworkBE.Application.DTOs;

namespace SocialNetworkBE.Application.Interfaces;

public interface IPlayerService
{
    Task<CreatePlayerDto> RegisterPlayerAsync(CreatePlayerDto createPlayerDto);
}