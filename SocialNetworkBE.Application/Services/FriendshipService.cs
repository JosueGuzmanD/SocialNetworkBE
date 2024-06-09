using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Application.Services;

public class FriendshipService : IFriendshipService
{
    private readonly IFriendshipRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public FriendshipService(IFriendshipRepository repository, IMapper mapper, IUserRepository userRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
public async Task<FriendshipDto> GetByIdAsync(Guid id)
    {
        var friendship = await _repository.GetByIdAsync(id);
        return _mapper.Map<FriendshipDto>(friendship);
    }

    public async Task DeleteAsync(Guid id)
    {
        var friendship = await _repository.GetByIdAsync(id);
        await _repository.RemoveAsync(friendship);
    }

    public async Task sendFriendshipRequest(FriendshipRequestDto friendshipDto)
    {
        var friendship = _mapper.Map<Friendship>(friendshipDto);

        friendship.Status = FriendshipStatus.Awaiting;
        friendship.Id = Guid.NewGuid();

        friendship.User1 = await _userRepository.GetByIdAsync(friendshipDto.User1Id);
        friendship.User1 = await _userRepository.GetByIdAsync(friendshipDto.User2Id);

        await _repository.AddAsync(friendship);
    }

    public async Task UpdateFriendshipStatus(Guid friendshipId, FriendshipStatus newStatus)
    {
        var friendship = await _repository.GetByIdAsync(friendshipId);
        friendship.Status = newStatus;
        await _repository.UpdateAsync(friendship);
    }


}
