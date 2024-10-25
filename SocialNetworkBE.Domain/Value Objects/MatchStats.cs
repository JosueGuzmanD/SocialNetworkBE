using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Value_Objects;

public class MatchStats
{
    public int GoalsTeamA { get; private set; }
    public int GoalsTeamB { get; private set; }
    public List<Player> ScorersTeamA { get; private set; } = new List<Player>();
    public List<Player> ScorersTeamB { get; private set; } = new List<Player>();

    public MatchStats(int goalsTeamA = 0, int goalsTeamB = 0)
    {
        GoalsTeamA = goalsTeamA;
        GoalsTeamB = goalsTeamB;
    }

    public void AddGoalForTeamA(Player player)
    {
        GoalsTeamA++;
        ScorersTeamA.Add(player);
    }

    public void AddGoalForTeamB(Player player)
    {
        GoalsTeamB++;
        ScorersTeamB.Add(player);
    }
}