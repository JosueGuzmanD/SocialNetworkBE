using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Repositories;

public interface IPlayerRepository
{
    Task<Player> GetPlayerByEmailAsync(string email);
    Task<List<Player>> GetPlayersByPositionAsync(Positions position);
    Task<List<Player>> GetPlayersByTeamAsync(Guid teamId);
    Task<List<Player>> GetTopScorersAsync(int limit);
}