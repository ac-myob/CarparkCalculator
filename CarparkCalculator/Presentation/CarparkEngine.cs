using CarparkCalculator.Application;
using CarparkCalculator.Models;

namespace CarparkCalculator.Presentation;

public class CarparkEngine : ICarparkEngine
{
    private readonly ICarparkService _carparkService;
    private readonly IReader _reader;
    private readonly IWriter _writer;

    public CarparkEngine(ICarparkService carparkService, IReader reader, IWriter writer)
    {
        _carparkService = carparkService;
        _reader = reader;
        _writer = writer;
    }
    
    public void Run()
    {
        _writer.Write("Entry date: ");
        var entry = GetValidDateTime();
        _writer.Write("Exit date: ");
        var exit = GetValidDateTime();
        var carparkDuration = new CarparkDuration(entry, exit);
        var carparkExpense = _carparkService.GetCost(carparkDuration);
        
        _writer.Write($"Rate name: {carparkExpense.CarparkRateName.GetString()}\n");
        _writer.Write($"Total cost: {carparkExpense.TotalCost}\n");
    }

    private DateTime GetValidDateTime()
    {
        DateTime? input = null;
        while (input == null)
        {
            _writer.Write("Please enter a date in the format of dd/mm/yy hh:mm: "); 
            input = _reader.ReadDateTime();
            if (input == null)
                _writer.Write("Invalid input. Please try again. ");
        }

        return (DateTime) input;
    }
}