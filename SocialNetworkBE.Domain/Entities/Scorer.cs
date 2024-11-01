namespace SocialNetworkBE.Domain.Entities;

public class Scorer
{
    public Guid Id { get; set; } 
    public Guid PlayerId { get; set; } 
    public bool IsTeamA { get; set; } 
}