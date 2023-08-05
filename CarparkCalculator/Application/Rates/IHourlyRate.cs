using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public interface IHourlyRate
{
    public CarparkRateName CarparkRateName { get; }
    public Money CalculateCost(CarparkDuration carparkDuration);
}