using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;
using FluentAssertions;

namespace CarparkCalculator.Tests.Rates;

public class EarlyBirdTests
{
    private readonly EarlyBird _earlyBird = new();
    
    [Theory]
    [MemberData(nameof(SatisfiesEntryAndExitConditionTestData))]
    public void SatisfiesRateCondition_ReturnsTrue_GivenCarparkDurationsIsWithinEntryAndExitCondition(
        CarparkDuration carparkDuration)
    {
        var actualBool = _earlyBird.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeTrue();
    }
    
    [Theory]
    [MemberData(nameof(DoesNotSatisfyEntryAndExitConditionTestData))]
    public void SatisfiesRateCondition_ReturnsFalse_GivenCarparkDurationsIsNotWithinEntryAndExitCondition(
        CarparkDuration carparkDuration)
    {
        var actualBool = _earlyBird.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeFalse();
    }

    private static IEnumerable<object[]> SatisfiesEntryAndExitConditionTestData()
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
    
    private static IEnumerable<object[]> DoesNotSatisfyEntryAndExitConditionTestData()
    {
        yield return new object[]
        {
        };
    }
}