using CarparkCalculator.Application;
using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

var flatRates = new List<IFlatRate>()
{
    new EarlyBird(),
    new NightRate(),
    new WeekendRate()
};

var hourlyRate = new StandardRate();

var carparkService = new CarparkService(flatRates, hourlyRate);

var startDateTime = new DateTime(2023, 01, 16, 18, 0, 0);
var endDateTime = new DateTime(2023, 01, 17, 5, 30, 0);
var carparkDuration = new CarparkDuration(startDateTime, endDateTime);

Console.WriteLine(carparkService.GetCost(carparkDuration).TotalCost.Amount);