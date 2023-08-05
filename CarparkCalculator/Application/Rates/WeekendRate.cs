using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public class WeekendRate : IFlatRate
{
    public CarparkRateName CarparkRateName => CarparkRateName.WeekendRate;

    public Money Cost { get; } = new(10.00m);
    
    public bool SatisfiesRateCondition(CarparkDuration carparkDuration)
    {
        var midnight = new TimeSpan(0, 0, 0);
        var entryFinishTime = new TimeSpan(23, 59, 59);
        var isEntryWeekend = carparkDuration.Entry.DayOfWeek >= DayOfWeek.Friday && 
                             carparkDuration.Entry.DayOfWeek <= DayOfWeek.Sunday;
        var isExitWeekend = carparkDuration.Exit.DayOfWeek <= DayOfWeek.Sunday;
        
        var satisfiesEntryCondition = 
            carparkDuration.Entry.TimeOfDay >= midnight && 
            carparkDuration.Entry.TimeOfDay <= entryFinishTime && 
            isEntryWeekend;
        var satisfiesExitCondition =
            carparkDuration.Exit.TimeOfDay < midnight &&
            isExitWeekend;

        return satisfiesEntryCondition && satisfiesExitCondition;
    }
}