using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Reaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public Guid? CommentId { get; set; }
    public ReactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }

    public Player User { get; set; }
    public Post Post { get; set; }
    public Comment? Comment { get; set; }
}
