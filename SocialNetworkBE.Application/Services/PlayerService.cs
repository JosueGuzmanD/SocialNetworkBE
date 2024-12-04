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
        _userManager = userManager;
    }


    public async Task<Result<CreatePlayerDto>> RegisterPlayerAsync(CreatePlayerDto createPlayerDto, string password)
    {
        var player = new Player
        {
            Name = createPlayerDto.Name,
            Email = createPlayerDto.Email,
            AvatarUrl = createPlayerDto.AvatarUrl,
            Bio = createPlayerDto.Bio
        };

        await _playerRepository.AddAsync(player);

        var applicationUser = new ApplicationUser
        {
            UserName = createPlayerDto.Email,
            Email = createPlayerDto.Email,
            PlayerId = player.Id
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, password);
        if (!identityResult.Succeeded) return Result<CreatePlayerDto>.Failure("Error creating user.");

        return Result<CreatePlayerDto>.Success(createPlayerDto);
    }

    //*Admin permission
    public async Task<Result<List<CreatePlayerDto>>> GetAllPlayersAsync()
    {
        var playerList = await _playerRepository.GetAllAsync();


        if (!playerList.Any()) return Result<List<CreatePlayerDto>>.Failure("No players found.");

        var playerListToDto = _mapper.Map<List<CreatePlayerDto>>(playerList);

        return Result<List<CreatePlayerDto>>.Success(playerListToDto);
    }
}