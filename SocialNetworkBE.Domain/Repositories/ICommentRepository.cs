using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Repositories;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);

    Task<IEnumerable<Comment>> GetCommentsByPlayerIdAsync(Guid playerId);

    Task<IEnumerable<Comment>> GetRecentCommentsByPostIdAsync(Guid postId, int limit);
}