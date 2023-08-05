namespace CarparkCalculator.Models;

public class CarparkExpense
{
    public CarparkRateName CarparkRateName { get; }
    public Money TotalCost { get; }

    public CarparkExpense(CarparkRateName carparkRateName, Money totalCost)
    {
        CarparkRateName = carparkRateName;
        TotalCost = totalCost;
    }
}