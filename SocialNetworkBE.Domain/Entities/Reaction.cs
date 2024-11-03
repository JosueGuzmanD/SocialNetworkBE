using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Reaction : BaseEntity
{
    public ReactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }

    public Player Player { get; set; }
    public Post Post { get; set; }
    public Comment? Comment { get; set; }
}