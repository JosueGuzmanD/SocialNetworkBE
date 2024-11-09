using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Specifications;
using SocialNetworkBE.Application.Validators;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    
    
    public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
        
    }

    public Task<CreatePlayerDto> RegisterPlayerAsync(CreatePlayerDto createPlayerDto)
    {
        var validator = new PlayerRegistrationValidator();
        validator.Validate(createPlayerDto);
        
        


    }
}