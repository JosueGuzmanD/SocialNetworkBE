using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Friendship
{
    public Guid Id { get; set; }
    public Guid User1Id { get; set; }
    public Guid User2Id { get; set; }

    public FriendshipStatus Status { get; set; }

    public Player User1 { get; set; }
    public Player User2 { get; set; }

}
