using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

namespace CarparkCalculator.Tests.Rates;

public class WeekendRateTests
{
    private readonly WeekendRate _weekendRate = new();
    
    [Theory]
    [MemberData(nameof(CarparkDurationTestData))]
    public void SatisfiesRateCondition_ReturnsTrue_GivenCarparkDurationsIsWithinEntryAndExitCondition(CarparkDuration carparkDuration)
    {
        var actualBool = _weekendRate.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeTrue();
    }

    private static IEnumerable<object[]> CarparkDurationTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(new DateTime(2000, 1, 15, 6, 0, 0), 
                new DateTime(2000, 1, 15, 15, 30, 0)),
        };
        
        yield return new object[]
        {
            new CarparkDuration(new DateTime(2000, 1, 1, 6, 0, 0), 
                new DateTime(2000, 1, 1, 15, 30, 0)),
        };
    }
}