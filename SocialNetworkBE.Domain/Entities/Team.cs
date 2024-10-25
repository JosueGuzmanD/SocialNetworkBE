using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

    public class Team: BaseEntity
    {
    public string Name { get; set; }
    public List<Player> Players { get; set; }
    public TeamStats Stats { get; set; } = new TeamStats();
    
    public bool isRecurrent { get; set; }

    }
