using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public List<Player> Players { get; set; } = new();
    public TeamStats Stats { get; private set; } = new();
    public bool isRecurrent { get; set; }
}