using CarparkCalculator.Models;

namespace CarparkCalculator.Application.Rates;

public interface IFlatRate
{
    public CarparkRateName CarparkRateName { get; }
    public Money Cost { get; }
    public bool SatisfiesRateCondition(CarparkDuration carparkDuration);
}