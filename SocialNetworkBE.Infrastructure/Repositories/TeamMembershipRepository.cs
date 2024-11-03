using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class TeamMembershipRepository : GenericRepository<TeamMembership>, ITeamMembershipRepository
{
    public TeamMembershipRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<List<TeamMembership>> GetMembershipsByPlayerIdAsync(Guid playerId)
    {
        return await _context.TeamMemberships
            .Where(tm => tm.PlayerId == playerId)
            .Include(tm => tm.Team)
            .ToListAsync();
    }

    public async Task<List<TeamMembership>> GetMembershipsByTeamIdAsync(Guid teamId)
    {
        return await _context.TeamMemberships
            .Where(tm => tm.TeamId == teamId)
            .Include(tm => tm.Player)
            .ToListAsync();
    }

    public async Task<List<TeamMembership>> GetActiveMembershipsAsync()
    {
        return await _context.TeamMemberships
            .Where(tm => tm.LeftDate == null)
            .ToListAsync();
    }

    public async Task<List<TeamMembership>> GetMembershipHistoryByPlayerIdAsync(Guid playerId)
    {
        return await _context.TeamMemberships
            .Where(tm => tm.PlayerId == playerId)
            .OrderByDescending(tm => tm.JoinedDate)
            .ToListAsync();
    }
}