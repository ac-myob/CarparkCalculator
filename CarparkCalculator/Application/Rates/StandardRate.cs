using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public class StandardRate : IHourlyRate
{
    public CarparkRateName CarparkRateName => CarparkRateName.StandardRate;
    public Money CalculateCost(CarparkDuration carparkDuration)
    {
        var elapsedHours = (carparkDuration.Exit - carparkDuration.Entry).TotalHours;
        var wholeHours = (decimal) Math.Round(elapsedHours);

        var totalCost = elapsedHours switch
        {
            < 1 => wholeHours * 5,
            < 2 => wholeHours * 10,
            < 3 => wholeHours * 15,
            _ => wholeHours * 20
        };

        return new Money(totalCost);
    }
}