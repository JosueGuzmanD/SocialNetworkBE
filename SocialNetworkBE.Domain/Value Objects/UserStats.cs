namespace SocialNetworkBE.Domain.Value_Objects;

public class PlayerStats
{
    public PlayerStats(int totalMatchesPlayed = 0, int goalsScored = 0, int wins = 0)
    {
        TotalMatchesPlayed = totalMatchesPlayed;
        GoalsScored = goalsScored;
        Wins = wins;
    }

    public int TotalMatchesPlayed { get; }
    public int GoalsScored { get; }
    public int Wins { get; }

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