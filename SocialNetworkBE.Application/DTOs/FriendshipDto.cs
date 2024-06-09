using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Application.DTOs;

public class FriendshipDto
{
    public Guid Id { get; set; }
    public Guid User1Id { get; set; }
    public Guid User2Id { get; set; }
    public FriendshipStatus Status { get; set; }
}

public class FriendshipRequestDto
{
    public Guid User1Id { get; set; }
    public Guid User2Id { get; set; }
    public FriendshipStatus Status { get; set; }
}