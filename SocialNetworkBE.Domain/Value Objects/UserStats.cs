namespace SocialNetworkBE.Domain.Value_Objects;

public class UserStats
{
    public int TotalMatchesPlayed { get; private set; }
    public int GoalsScored { get; private set; }
    public int Wins { get; private set; }

    public UserStats(int totalMatchesPlayed = 0, int goalsScored = 0, int wins = 0)
    {
        TotalMatchesPlayed = totalMatchesPlayed;
        GoalsScored = goalsScored;
        Wins = wins;
    }

    public UserStats AddMatchPlayed()
    {
        return new UserStats(TotalMatchesPlayed + 1, GoalsScored, Wins);
    }

    public UserStats AddGoalScored()
    {
        return new UserStats(TotalMatchesPlayed, GoalsScored + 1, Wins);
    }

    public UserStats AddWin()
    {
        return new UserStats(TotalMatchesPlayed, GoalsScored, Wins + 1);
    }
}