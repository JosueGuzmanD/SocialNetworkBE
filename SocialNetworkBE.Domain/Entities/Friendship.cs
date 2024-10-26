using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Friendship: BaseEntity
{
    public FriendshipStatus Status { get; set; }

    public Player User1 { get; set; }
    public Player User2 { get; set; }

}
