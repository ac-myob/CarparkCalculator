namespace CarparkCalculator.Models;

public class InvalidDateException : Exception
{
    public InvalidDateException(string message) : base(message)
    {
        
    }
}