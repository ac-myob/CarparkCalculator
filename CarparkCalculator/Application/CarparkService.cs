using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

namespace CarparkCalculator.Application;

public class CarparkService : ICarparkService
{
    private readonly IEnumerable<IFlatRate> _flatRates;
    private readonly IHourlyRate _hourlyRate;

    public CarparkService(IEnumerable<IFlatRate> flatRates, IHourlyRate hourlyRate)
    {
        _flatRates = flatRates;
        _hourlyRate = hourlyRate;
    }

    public CarparkExpense GetCost(CarparkDuration carparkDuration)
    {
        var flatRate = _flatRates.FirstOrDefault(rate => rate.SatisfiesRateCondition(carparkDuration));
        var carparkRateName = flatRate?.CarparkRateName ?? _hourlyRate.CarparkRateName;
        var totalCost = flatRate?.Cost ?? _hourlyRate.CalculateCost(carparkDuration);

        return new CarparkExpense(carparkRateName, totalCost);
    }
}