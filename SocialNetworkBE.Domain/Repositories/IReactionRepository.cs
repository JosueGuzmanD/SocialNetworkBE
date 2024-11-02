using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Repositories;

public interface IReactionRepository : IGenericRepository<Reaction>
{
    Task<List<Reaction>> GetReactionsByPostIdAsync(Guid postId);
    Task<List<Reaction>> GetReactionsByCommentIdAsync(Guid commentId);
    Task<List<Reaction>> GetReactionsByPlayerIdAsync(Guid playerId);
    Task<int> CountReactionsByTypeAsync(Guid postId, ReactionType type);
}