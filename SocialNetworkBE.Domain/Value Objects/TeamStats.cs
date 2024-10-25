namespace SocialNetworkBE.Domain.Value_Objects;

public class TeamStats
{
    public int TotalMatchesPlayed { get; private set; }
    public int Wins { get; private set; }
    public int Losses { get; private set; }

    public TeamStats(int totalMatchesPlayed = 0, int wins = 0, int losses = 0)
    {
        TotalMatchesPlayed = totalMatchesPlayed;
        Wins = wins;
        Losses = losses;
    }

    public TeamStats AddWin()
    {
        return new TeamStats(TotalMatchesPlayed + 1, Wins + 1, Losses);
    }

    public TeamStats AddLoss()
    {
        return new TeamStats(TotalMatchesPlayed + 1, Wins, Losses + 1);
    }
}