using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Interfaces.Repositories;

public interface ITeamMembershipRepository : IGenericRepository<TeamMembership>
{
    Task<List<TeamMembership>> GetMembershipsByPlayerIdAsync(Guid playerId);
    Task<List<TeamMembership>> GetMembershipsByTeamIdAsync(Guid teamId);
    Task<List<TeamMembership>> GetActiveMembershipsAsync();
    Task<List<TeamMembership>> GetMembershipHistoryByPlayerIdAsync(Guid playerId);
}
