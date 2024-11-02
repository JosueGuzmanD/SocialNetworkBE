using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Notification : BaseEntity
{
    public NotificationType Type { get; set; }
    public string Content { get; set; }
    public bool IsRead { get; set; }
    public Player User { get; set; }
}