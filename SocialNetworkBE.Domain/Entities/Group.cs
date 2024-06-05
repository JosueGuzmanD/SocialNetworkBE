namespace SocialNetworkBE.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CreatorId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}

    public User Creator { get; set; }
    public ICollection<GroupMembership> GroupMemberships { get; set; }
}
