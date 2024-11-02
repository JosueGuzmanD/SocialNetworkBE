using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Repositories;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<List<Post>> GetPostsByPlayerIdAsync(Guid playerId);
    Task<List<Post>> GetMatchAnnouncementsAsync();
    Task<List<Post>> GetResultAnnouncementsAsync();
    Task<List<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate);
}