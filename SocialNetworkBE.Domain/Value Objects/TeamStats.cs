namespace SocialNetworkBE.Domain.Value_Objects;

public class TeamStats
{
    public TeamStats(int totalMatchesPlayed = 0, int wins = 0, int losses = 0)
    {
        TotalMatchesPlayed = totalMatchesPlayed;
        Wins = wins;
        Losses = losses;
    }

    public int TotalMatchesPlayed { get; }
    public int Wins { get; }
    public int Losses { get; }

    public TeamStats AddWin()
    {
        return new TeamStats(TotalMatchesPlayed + 1, Wins + 1, Losses);
    }

    public TeamStats AddLoss()
    {
        return new TeamStats(TotalMatchesPlayed + 1, Wins, Losses + 1);
    }
}