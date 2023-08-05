using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public class EarlyBird : IFlatRate
{
    public CarparkRateName CarparkRateName => CarparkRateName.EarlyBird;

    public Money Cost { get; } = new Money(13.00m);
    
    public bool SatisfiesRateCondition(CarparkDuration carparkDuration)
    {
        var entryStartTime = new TimeSpan(6, 0, 0);
        var entryFinishTime = new TimeSpan(9, 0, 0);
        var exitStartTime = new TimeSpan(15, 30, 0);
        var exitFinishTime = new TimeSpan(23, 30, 0);
        
        var satisfiesEntryCondition = 
            carparkDuration.Entry.TimeOfDay >= entryStartTime && 
            carparkDuration.Entry.TimeOfDay <= entryFinishTime;
        var satisfiesExitCondition = 
            carparkDuration.Exit.TimeOfDay >= exitStartTime && 
            carparkDuration.Exit.TimeOfDay <= exitFinishTime;

        return satisfiesEntryCondition && satisfiesExitCondition;
    }
}