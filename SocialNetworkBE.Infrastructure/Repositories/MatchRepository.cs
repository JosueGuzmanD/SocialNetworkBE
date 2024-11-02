using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class MatchRepository : GenericRepository<Match>, IMatchRepository
{
    public MatchRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Match>> GetMatchesByCreator(Guid playerId)
    {
        return await _context.Matches
            .Where(m => m.CreatedBy.Id == playerId)
            .Include(m => m.Stats)
            .Include(m => m.FootballField)
            .Include(m => m.Players)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesByPlayer(Guid playerId)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);

        return await _context.Matches
            .Where(m => m.Players.Any(p => p.Id == playerId))
            .Include(m => m.Players)
            .Include(m => m.Stats)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesByField(Guid fieldId)
    {
        return await _context.Matches
            .Where(m => m.FootballField.Id == fieldId)
            .Include(m => m.FootballField)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchByStatus(MatchStatus status)
    {
        return await _context.Matches
            .Where(m => m.Status == status)
            .Include(m => m.Players)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesByDateRange(DateTime startDate, DateTime endDate)
    {
        return await _context.Matches
            .Where(m => m.StartTime >= startDate && m.StartTime <= endDate)
            .Include(m => m.Players)
            .Include(m => m.Stats)
            .ToListAsync();
    }
}