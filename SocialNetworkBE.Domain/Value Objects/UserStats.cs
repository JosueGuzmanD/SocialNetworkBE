namespace SocialNetworkBE.Domain.Value_Objects;

public class PlayerStats
{
    public int TotalMatchesPlayed { get; private set; }
    public int GoalsScored { get; private set; }
    public int Wins { get; private set; }

    public PlayerStats(int totalMatchesPlayed = 0, int goalsScored = 0, int wins = 0)
    {
        TotalMatchesPlayed = totalMatchesPlayed;
        GoalsScored = goalsScored;
        Wins = wins;
    }

    public PlayerStats AddMatchPlayed()
    {
        return new PlayerStats(TotalMatchesPlayed + 1, GoalsScored, Wins);
    }

    public PlayerStats AddGoalScored()
    {
        return new PlayerStats(TotalMatchesPlayed, GoalsScored + 1, Wins);
    }

    public PlayerStats AddWin()
    {
        return new PlayerStats(TotalMatchesPlayed, GoalsScored, Wins + 1);
    }
}