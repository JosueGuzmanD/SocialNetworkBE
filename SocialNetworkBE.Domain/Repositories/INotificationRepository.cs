using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Repositories;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<List<Notification>> GetAllNotificationsByUserIdAsync(Guid userId);
    Task<List<Notification>> GetAllByUserIdAndDateAsync(Guid userId, DateTime date);
    Task<List<Notification>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<List<Notification>> GetByTypeAsync(NotificationType type);
    Task<List<Notification>> GetReadNotificationsAsync();
    Task<List<Notification>> GetUnreadNotificationsAsync();
}