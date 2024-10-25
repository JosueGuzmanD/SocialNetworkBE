using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string AvatarUrl { get; set; }
    
    public List<Positions> Positions { get; set; } = new();
    
    public UserStats Stats { get; private set; } = new UserStats();  


    public ICollection<Friendship> Friendships { get; set; }
    public ICollection<GroupMembership> GroupMemberships { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    public ICollection<Message> SentMessages { get; set; }
    public ICollection<Message> ReceivedMessages { get; set; }


}
