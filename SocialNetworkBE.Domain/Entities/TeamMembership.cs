namespace SocialNetworkBE.Domain.Entities;

public class TeamMembership : BaseEntity
{
    public Guid PlayerId { get; set; }
    public Player Player { get; set; }

    public Guid TeamId { get; set; }
    public Team Team { get; set; }

    public DateTime JoinedDate { get; set; }
    public DateTime? LeftDate { get; set; }
}