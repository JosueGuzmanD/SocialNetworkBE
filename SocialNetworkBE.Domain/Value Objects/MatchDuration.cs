namespace SocialNetworkBE.Domain.Value_Objects;

public class MatchDuration
{
    public MatchDuration(TimeSpan totalTime, TimeSpan halfTimeDuration, TimeSpan extraTime, TimeSpan waterBreakDuration,
        TimeSpan addedTime)
    {
        if (totalTime.TotalMinutes < 30 || totalTime.TotalMinutes > 120)
            throw new ArgumentException("A match duration should be between 30 and 120 minutes.");

        TotalTime = totalTime;
        HalfTimeDuration = halfTimeDuration;
        ExtraTime = extraTime;
        WaterBreakDuration = waterBreakDuration;
        AddedTime = addedTime;
    }

    public TimeSpan TotalTime { get; }
    public TimeSpan HalfTimeDuration { get; private set; }
    public TimeSpan ExtraTime { get; }
    public TimeSpan WaterBreakDuration { get; private set; }
    public TimeSpan AddedTime { get; }

    public TimeSpan GetFinalTimeWithExtras()
    {
        return TotalTime.Add(ExtraTime).Add(AddedTime);
    }
}