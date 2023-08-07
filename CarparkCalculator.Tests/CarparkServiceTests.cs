using CarparkCalculator.Application;
using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;
using Moq;

namespace CarparkCalculator.Tests;

public class CarparkServiceTests
{
    private readonly Mock<IFlatRate> _flatRate = new();
    private readonly Mock<IHourlyRate> _hourlyRate = new();
    private readonly CarparkService _carparkService;

    public CarparkServiceTests()
    {
        var flatRates = new List<IFlatRate> {_flatRate.Object};
        _carparkService = new CarparkService(flatRates, _hourlyRate.Object);
    }

    [Fact]
    public void GetCost_ReturnsCorrectCarparkExpense_GivenCarparkDurationUsesFlatRate()
    {
        var carparkRateName = CarparkRateName.EarlyBird;
        var money = new Money(0);
        var expectedCarparkExpense = new CarparkExpense(carparkRateName, money);
        var carparkDuration = It.IsAny<CarparkDuration>();
        _flatRate.Setup(_ => _.Cost).Returns(money);
        _flatRate.Setup(_ => _.CarparkRateName).Returns(carparkRateName);
        _flatRate.Setup(_ => _.SatisfiesRateCondition(carparkDuration)).Returns(true);

        var actualCarparkExpense = _carparkService.GetCost(carparkDuration);

        actualCarparkExpense.Should().BeEquivalentTo(expectedCarparkExpense);
    }
    
    [Fact]
    public void GetCost_ReturnsCorrectCarparkExpense_GivenCarparkDurationUsesHourlyRate()
    {
        var carparkRateName = CarparkRateName.EarlyBird;
        var money = new Money(100);
        var expectedCarparkExpense = new CarparkExpense(carparkRateName, money);
        var carparkDuration = It.IsAny<CarparkDuration>();
        _flatRate.Setup(_ => _.SatisfiesRateCondition(carparkDuration)).Returns(false);
        _hourlyRate.Setup(_ => _.CarparkRateName).Returns(carparkRateName);
        _hourlyRate.Setup(_ => _.CalculateCost(carparkDuration)).Returns(money);
        

        var actualCarparkExpense = _carparkService.GetCost(carparkDuration);

        actualCarparkExpense.Should().BeEquivalentTo(expectedCarparkExpense);
    }
}