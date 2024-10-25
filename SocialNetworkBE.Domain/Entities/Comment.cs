namespace SocialNetworkBE.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Player User { get; set; }
    public Post Post { get; set; }
    public IEnumerable<Reaction> Reactions { get; set; }
}
