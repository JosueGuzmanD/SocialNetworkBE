using SocialNetworkBE.Application.DTOs;

namespace SocialNetworkBE.Application.Interfaces;

public interface IPlayerService
{
    Task<Result<CreatePlayerDto>> RegisterPlayerAsync(CreatePlayerDto createPlayerDto, string password);

}