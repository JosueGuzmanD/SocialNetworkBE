using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class CommentRepository: GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId)
    {
        return await _context.Comments
            .Where(c => c.Post.Id == postId)
            .Include(c=>c.Player)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPlayerIdAsync(Guid playerId)
    {
        return await _context.Comments
            .Where(c => c.Player.Id == playerId)
            .Include(c => c.Post)
            .Include(c => c.Player)
            .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetRecentCommentsByPostIdAsync(Guid postId, int limit)
    {
        return await _context.Comments
            .Where(c => c.Post.Id == postId)
            .Include(c => c.Post)
            .Include(c => c.Player)
            .OrderByDescending(c=>c.CreationDate.Date)
            .Take(limit)
            .ToListAsync();
    }
}