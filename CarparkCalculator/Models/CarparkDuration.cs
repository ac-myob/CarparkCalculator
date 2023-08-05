namespace CarparkCalculator.Models;

public class CarparkDuration
{
    public DateTime Entry { get; }
    public DateTime Exit { get; }

    public CarparkDuration(DateTime entry, DateTime exit)
    {

        if (entry > exit)
            throw new InvalidDateException("Entry date cannot be after exit date");
        
        Entry = entry;
        Exit = exit;
    }
}