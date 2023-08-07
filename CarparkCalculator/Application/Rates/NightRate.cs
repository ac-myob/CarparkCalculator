using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public class NightRate : IFlatRate
{
    public CarparkRateName CarparkRateName => CarparkRateName.NightRate;
    public Money Cost { get; } = new(6.50m);

    public bool SatisfiesRateCondition(CarparkDuration carparkDuration)
    {
        var entryStartTime = new TimeSpan(18, 0, 0);
        var midnight = new TimeSpan(0, 0, 0);
        var exitFinishTime = new TimeSpan(6, 0, 0);
        var isEntryWeekday = carparkDuration.Entry.DayOfWeek != DayOfWeek.Saturday && 
                             carparkDuration.Entry.DayOfWeek != DayOfWeek.Sunday;
        
        var satisfiesEntryCondition = 
            (carparkDuration.Entry.TimeOfDay >= entryStartTime || carparkDuration.Entry.TimeOfDay == midnight) && 
            isEntryWeekday;
        var satisfiesExitCondition =
            carparkDuration.Exit.TimeOfDay < exitFinishTime;

        return satisfiesEntryCondition && satisfiesExitCondition;
    }
}