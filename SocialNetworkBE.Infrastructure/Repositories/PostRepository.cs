using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    public PostRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<List<Post>> GetPostsByPlayerIdAsync(Guid playerId)
    {
        return await _context.Posts
            .Where(p => p.CreatedBy.Id == playerId)
            .ToListAsync();
    }

    public async Task<List<Post>> GetMatchAnnouncementsAsync()
    {
        return await _context.Posts
            .Where(p => p.PostType == PostType.MatchAnnouncement)
            .ToListAsync();
    }

    public async Task<List<Post>> GetResultAnnouncementsAsync()
    {
        return await _context.Posts
            .Where(p => p.PostType == PostType.ResultAnnouncement)
            .ToListAsync();    }

    public async Task<List<Post>> GetPostsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Posts
            .Where(p => p.CreationDate >= startDate && p.CreationDate <= endDate)
            .ToListAsync();
    }
}