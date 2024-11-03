namespace SocialNetworkBE.Domain.Value_Objects;

public class MatchStats
{
    public MatchStats(int goalsTeamA = 0, int goalsTeamB = 0)
    {
        GoalsTeamA = goalsTeamA;
        GoalsTeamB = goalsTeamB;
    }

    public int GoalsTeamA { get; private set; }
    public int GoalsTeamB { get; private set; }
    public List<Scorer> Scorers { get; } = new();

    public void AddGoalForTeamA(Guid playerId)
    {
        GoalsTeamA++;
        Scorers.Add(new Scorer { PlayerId = playerId, IsTeamA = true });
    }

    public void AddGoalForTeamB(Guid playerId)
    {
        GoalsTeamB++;
        Scorers.Add(new Scorer { PlayerId = playerId, IsTeamA = false });
    }
}