﻿using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Interfaces.Repositories;

public interface ITeamRepository : IGenericRepository<Team>
{
    Task<Team> GetTeamByNameAsync(string name);
    Task<List<Team>> GetTeamsByPlayerIdAsync(Guid playerId);
    Task<List<Team>> GetRecurrentTeamsAsync();
}