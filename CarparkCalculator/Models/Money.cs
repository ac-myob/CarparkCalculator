namespace CarparkCalculator.Models;

public class Money
{
    public decimal Amount { get; }
    
    public Money(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        
        Amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
    }

    public override string ToString() => Amount.ToString("C");
}