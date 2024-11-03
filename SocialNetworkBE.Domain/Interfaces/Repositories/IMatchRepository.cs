using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Interfaces.Repositories;

public interface IMatchRepository : IGenericRepository<Match>
{
    Task<IEnumerable<Match>> GetMatchesByCreator(Guid playerId);
    Task<IEnumerable<Match>> GetMatchesByPlayer(Guid playerId);
    Task<IEnumerable<Match>> GetMatchesByField(Guid fieldId);
    Task<IEnumerable<Match>> GetMatchByStatus(MatchStatus status);
    Task<IEnumerable<Match>> GetMatchesByDateRange(DateTime startDate, DateTime endDate);
}