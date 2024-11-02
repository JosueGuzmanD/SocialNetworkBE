using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

public class Match : BaseEntity
{
    public DateTime StartTime { get; set; }
    public MatchDuration MatchDuration { get; set; }
    public FootballField FootballField { get; set; }
    public MatchStatus Status { get; set; }
    public List<Player> Players { get; set; } = new();
    public Player CreatedBy { get; set; }

    public MatchStats Stats { get; set; } = new();
}