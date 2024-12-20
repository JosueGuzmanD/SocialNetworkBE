using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
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

    public async Task<Result<PlayerDto>> GetPlayerByIdAsync(Guid id)
    {
        var result = await _playerRepository.GetByIdAsync(id);

        if (result == null)
        {
            return Result<PlayerDto>.Failure("No player found.");
        }

        return Result<PlayerDto>.Success(_mapper.Map<PlayerDto>(result));
    }

    public async Task<Result<List<PlayerDto>>> GetTopScorersAsync(int limit)
    {
        var result = await _playerRepository.GetTopScorersAsync(limit);

        if (result == null)
        {
            return Result<List<PlayerDto>>.Failure("No players found.");
        }

        return Result<List<PlayerDto>>.Success(_mapper.Map<List<PlayerDto>>(result));
    }

    public async Task<Result<PlayerDto>> UpdatePlayerAsync(Guid playerId, UpdatePlayerDto updatePlayerDto)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);

        if (player == null)
        {
            return Result<PlayerDto>.Failure("Player not found.");
        }

        _mapper.Map(updatePlayerDto, player);
        try
        {
            await _playerRepository.UpdateAsync(player);

            var playerDto = _mapper.Map<PlayerDto>(player);

            return Result<PlayerDto>.Success(playerDto);
        }
        catch (Exception ex)
        {
            return Result<PlayerDto>.Failure($"An error occurred while updating the player: {ex.Message}");
        }
    }

    public async Task<Result<List<PlayerDto>>> SearchPlayersAsync(PlayerQueryDto query)
    {
        var players = _playerRepository.GetQueryable();

         players= ApplyFilters(players, query);
        
        var result = await players.ToListAsync();

        if (!result.Any())
        {
            return Result<List<PlayerDto>>.Failure("No players found matching the criteria.");
        }

        var playerDtos = _mapper.Map<List<PlayerDto>>(result);
        return Result<List<PlayerDto>>.Success(playerDtos);

    }

    private IQueryable<Player> ApplyFilters(IQueryable<Player> players, PlayerQueryDto query)
    {
        if (!string.IsNullOrEmpty(query.Name))
        {
            players= players.Where(p => p.Name.Contains(query.Name));
        }

        if (!string.IsNullOrEmpty(query.Email))
        {
            players= players.Where(p => p.Email.Contains(query.Email));
        }

        if (query.MaxGoals.HasValue)
        {
            players= players.Where(p=> p.Stats.GoalsScored <= query.MaxGoals.Value);
        }

        if (query.MinGoals.HasValue)
        {
            players = players.Where(p => p.Stats.GoalsScored >= query.MinGoals.Value);
        }

        return players;
    }
    
}