using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Value_Objects;
using System.Collections.Generic;

namespace SocialNetworkBE.Domain.Entities;

public class Match : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTIme { get; set; }
    public MatchDuration MatchDuration { get; set; }
    public FootballField FootballField { get; set; }
    public Guid FieldId { get; set; }
    public MatchStatus Status {get; set; } 
    public List<Player> Players { get; set; }= new List<Player>();
    public Player CreatedBy { get; set; }

    public MatchStats Stats { get; set; } = new MatchStats();  

}
