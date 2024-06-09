using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Application.Interfaces;

public interface IFriendshipService
{
    Task<FriendshipDto> GetByIdAsync(Guid id);
    Task sendFriendshipRequest(FriendshipRequestDto friendshipDto);
    Task DeleteAsync(Guid id);
    Task UpdateFriendshipStatus(Guid friendshipId, FriendshipStatus newStatus);
}
