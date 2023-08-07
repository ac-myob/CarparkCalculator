using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

namespace CarparkCalculator.Tests.Rates;

public class NightRateTests
{
    private readonly NightRate _nightRate = new();
    
    [Theory]
    [MemberData(nameof(CarparkDurationTestData))]
    public void SatisfiesRateCondition_ReturnsTrue_GivenCarparkDurationsIsWithinEntryAndExitCondition(
        CarparkDuration carparkDuration)
    {
        var actualBool = _nightRate.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeTrue();
    }

    private static IEnumerable<object[]> CarparkDurationTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(3, 1,2023,18), 
                TestHelper.GenerateDateAndTime(4, 1,2023,5, 59))
        };
        
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(3, 1,2023, 20, 30), 
                TestHelper.GenerateDateAndTime(4, 1, 2023,4))
        };
        
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(3, 1,2023), 
                TestHelper.GenerateDateAndTime(4, 1, 2023,5, 59))
        };
    }
}