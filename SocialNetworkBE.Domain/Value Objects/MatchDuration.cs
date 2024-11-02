using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBE.Domain.Value_Objects;

public class MatchDuration
{
    public TimeSpan TotalTime { get; private set; }
    public TimeSpan HalfTimeDuration { get; private set; }
    public TimeSpan ExtraTime { get; private set; }
    public TimeSpan WaterBreakDuration { get; private set; }
    public TimeSpan AddedTime { get; private set; }

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

    public TimeSpan GetFinalTimeWithExtras()
    {
        return TotalTime.Add(ExtraTime).Add(AddedTime);
    }
}