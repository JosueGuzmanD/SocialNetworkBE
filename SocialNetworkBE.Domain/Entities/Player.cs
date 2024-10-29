using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

public class Player : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string AvatarUrl { get; set; }
    
    public List<Match> CreatedMatches { get; set; } = new List<Match>();
    
    public List<Positions> Positions { get; set; } = new();
    public List<Booking> Bookings { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Post> Posts { get; set; } = new();
    public UserStats Stats { get; private set; } = new UserStats();  


}
