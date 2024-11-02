using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<List<Notification>> GetAllNotificationsByUserIdAsync(Guid userId)
    {
        return await _context.Notifications
            .Where(n => n.User.Id == userId)
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetAllByUserIdAndDateAsync(Guid userId, DateTime date)
    {
        return await _context.Notifications
            .Where(n => n.User.Id == userId && n.CreationDate.Date == date)
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Notifications
            .Where(n => n.CreationDate.Date >= startDate && n.CreationDate.Date <= endDate)
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetByTypeAsync(NotificationType type)
    {
        return await _context.Notifications
            .Where(n => n.Type == type)
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetReadNotificationsAsync()
    {
        return await _context.Notifications
            .Where(n => n.IsRead == true)
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<List<Notification>> GetUnreadNotificationsAsync()
    {
        return await _context.Notifications
            .Where(n => n.IsRead == false)
            .Include(n => n.User)
            .ToListAsync();
    }
}