using CarparkCalculator.Application;
using CarparkCalculator.Application.Rates;
using CarparkCalculator.Presentation;

var flatRates = new List<IFlatRate>
{
    new EarlyBird(),
    new NightRate(),
    new WeekendRate()
};

ICarparkService carparkService = new CarparkService(flatRates, new StandardRate());
ICarparkEngine carparkEngine = new CarparkEngine(carparkService, new Reader(), new Writer());

carparkEngine.Run();