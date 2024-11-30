using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Specifications;
using SocialNetworkBE.Application.Validators;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    
    
    public PlayerService(IPlayerRepository playerRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
        _userManager= userManager;
        
    }


    public async Task<Result<CreatePlayerDto>> RegisterPlayerAsync(CreatePlayerDto createPlayerDto,string password)
    {
        var validator = new PlayerRegistrationValidator(_playerRepository);
        await validator.ValidateAsync(createPlayerDto);

        var user = new ApplicationUser()
        {
            UserName = createPlayerDto.Name,
            Email = createPlayerDto.Email,
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return Result<CreatePlayerDto>.Failure(
                $"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        var player = new Player()
        {
            Name = createPlayerDto.Name,
            Email = createPlayerDto.Email,
            AvatarUrl = createPlayerDto.AvatarUrl,
        };
        
        await _playerRepository.AddAsync(player);
        
        user.PlayerId = player.Id;
        await _userManager.UpdateAsync(user);
        
        
        return Result<CreatePlayerDto>.Success(createPlayerDto);

    }
}