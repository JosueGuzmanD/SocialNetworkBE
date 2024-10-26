using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Post :BaseEntity
{
    public string Content { get; set; }
    public Player CreatedBy { get; set; }  
    public List<Comment> Comments { get; set; }
    public List<Reaction> Reactions { get; set; }

    public PostType PostType { get; set; }  
    public Guid? MatchId { get; set; }  


}
