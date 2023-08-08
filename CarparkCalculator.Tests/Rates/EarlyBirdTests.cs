using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

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
            new CarparkDuration(TestHelper.GenerateTime(6), TestHelper.GenerateTime(23, 30))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(15, 30))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(7, 30), TestHelper.GenerateTime(19, 30))
        };
    }
    
    private static IEnumerable<object[]> DoesNotSatisfyEntryAndExitConditionTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(5, 59), TestHelper.GenerateTime(23, 30))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(6), TestHelper.GenerateTime(23, 31))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9, 1), TestHelper.GenerateTime(15, 30))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(15, 29))
        };
    }
}