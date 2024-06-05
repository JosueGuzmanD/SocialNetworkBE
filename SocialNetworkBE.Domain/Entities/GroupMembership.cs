using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class GroupMembership
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public Guid UserId { get; set; }
    public GroupRole role { get; set; }
    public DateTime JoinedAt { get; set; }

    public Group Group { get; set; }
    public User User { get; set; }
}
