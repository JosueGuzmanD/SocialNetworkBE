namespace SocialNetworkBE.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Reaction> Reactions { get; set; }


}
