using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class PlayerRepository: GenericRepository<Player>, IPlayerRepository
{
    public PlayerRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<Player> GetPlayerByEmailAsync(string email)
    {
        return await _context.Players
            .Where(p => p.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Player>> GetPlayersByPositionAsync(Positions position)
    {
        return await _context.Players
            .Where(p => p.Positions.Contains(position))
            .ToListAsync();
    }

    public async Task<List<Player>> GetPlayersByTeamAsync(Guid teamId)
    {
        return await _context.Players
            .Where(p => p.TeamHistory.Any(th=>th.TeamId == teamId))
            .ToListAsync();

    }
    public async Task<List<Player>> GetTopScorersAsync(int limit)
    {
        return await _context.Players
            .OrderByDescending(p => p.Stats.GoalsScored) 
            .Take(limit)
            .ToListAsync();
    }
}