using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<Team> GetTeamByNameAsync(string name)
    {
        return await _context.Teams
            .Where(t => t.Name == name)
            .FirstOrDefaultAsync();
    }

    public Task<List<Team>> GetTeamsByPlayerIdAsync(Guid playerId)
    {
        return _context.Teams
            .Where(t => t.Players.Any(p => p.Id == playerId))
            .ToListAsync();
    }

    public async Task<List<Team>> GetRecurrentTeamsAsync()
    {
        return await _context.Teams
            .Where(t => t.isRecurrent)
            .ToListAsync();
    }
}