namespace CarparkCalculator.Presentation;

public class Reader : IReader
{
    public DateTime? ReadDateTime()
    {
        const string dateTimeFormat = "dd/MM/yyyy HH:mm";
        try
        {
            var input = Console.ReadLine() ?? string.Empty;
            return DateTime.ParseExact(input, dateTimeFormat, null);
        }
        catch (FormatException)
        {
            return null;
        }
    }
}
