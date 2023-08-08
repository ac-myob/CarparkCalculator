using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public class WeekendRate : IFlatRate
{
    public CarparkRateName CarparkRateName => CarparkRateName.WeekendRate;

    public Money Cost { get; } = new(10.00m);

    private static bool IsWeekend(DayOfWeek dayOfWeek)
    {
        return dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }
    
    public bool SatisfiesRateCondition(CarparkDuration carparkDuration)
    {
        var midnight = new TimeSpan(0, 0, 0);
        var satisfiesEntryCondition = 
            carparkDuration.Entry.TimeOfDay >= midnight && IsWeekend(carparkDuration.Entry.DayOfWeek) || 
            carparkDuration.Entry.TimeOfDay > midnight && carparkDuration.Entry.DayOfWeek == DayOfWeek.Friday ;
        var satisfiesExitCondition = IsWeekend(carparkDuration.Exit.DayOfWeek) || 
                                     carparkDuration.Exit.DayOfWeek == DayOfWeek.Friday;

        return satisfiesEntryCondition && satisfiesExitCondition;
    }
}