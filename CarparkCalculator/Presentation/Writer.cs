namespace CarparkCalculator.Presentation;

public class Writer : IWriter
{
    public void Write(string message)
    {
        Console.Write(message);
    }
}