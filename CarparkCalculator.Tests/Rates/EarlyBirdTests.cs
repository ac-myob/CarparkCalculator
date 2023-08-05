using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;
using FluentAssertions;

namespace CarparkCalculator.Tests.Rates;

public class EarlyBirdTests
{
    private readonly EarlyBird _earlyBird = new();
    
    [Theory]
    [MemberData(nameof(temp))]
    public void SatisfiesRateCondition_ReturnsTrue_GivenCarparkDurationsIsWithinEntryAndExitCondition(CarparkDuration carparkDuration)
    {
        var actualBool = _earlyBird.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeTrue();
    }

    private IEnumerable<object[]> temp()
    {
        yield return new object[]
        {
            new CarparkDuration(new DateTime(2000, 01, 15, 6, 0, 0), 
                new DateTime(2000, 01, 01, 15, 30, 0)),
        };
        
        yield return new object[]
        {
            new CarparkDuration(new DateTime(2000, 01, 15, 6, 0, 0), 
                new DateTime(2000, 01, 01, 15, 30, 0)),
        };
    }
}