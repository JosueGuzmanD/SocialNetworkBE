using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class ReactionRepository: GenericRepository<Reaction>, IReactionRepository
{
    public ReactionRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<List<Reaction>> GetReactionsByPostIdAsync(Guid postId)
    {
        return await _context.Reactions
            .Where(r => r.Post.Id == postId)
            .ToListAsync();
    }

    public async Task<List<Reaction>> GetReactionsByCommentIdAsync(Guid commentId)
    {
        return await _context.Reactions
            .Where(r => r.Comment.Id == commentId)
            .ToListAsync();
    }

    public async Task<List<Reaction>> GetReactionsByPlayerIdAsync(Guid playerId)
    {
        return await _context.Reactions
            .Where(r => r.Player.Id == playerId)
            .ToListAsync(); 
    }

    public async Task<int> CountReactionsByTypeAsync(Guid postId, ReactionType type)
    {
        return await _context.Reactions
            .Where(r => r.Post.Id == postId && r.Type == type)
            .CountAsync();
    }
}