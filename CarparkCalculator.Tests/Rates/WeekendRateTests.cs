using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

namespace CarparkCalculator.Tests.Rates;

public class WeekendRateTests
{
    private readonly WeekendRate _weekendRate = new();
    
    [Theory]
    [MemberData(nameof(SatisfiesEntryAndExitConditionTestData))]
    public void SatisfiesRateCondition_ReturnsTrue_GivenCarparkDurationsIsWithinEntryAndExitCondition(CarparkDuration carparkDuration)
    {
        var actualBool = _weekendRate.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeTrue();
    }
    
    [Theory]
    [MemberData(nameof(DoesNotSatisfyEntryAndExitConditionTestData))]
    public void SatisfiesRateCondition_ReturnsFalse_GivenCarparkDurationsIsNotWithinEntryAndExitCondition(CarparkDuration carparkDuration)
    {
        var actualBool = _weekendRate.SatisfiesRateCondition(carparkDuration);

        actualBool.Should().BeFalse();
    }

    private static IEnumerable<object[]> SatisfiesEntryAndExitConditionTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateDateAndTime(6, 1, 2023, 0, 1), 
                TestHelper.GenerateDateAndTime(8, 1, 2023, 23, 59))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateDateAndTime(8, 1, 2023), 
                TestHelper.GenerateDateAndTime(8, 1, 2023, 23, 59))
        };
    }
    
    private static IEnumerable<object[]> DoesNotSatisfyEntryAndExitConditionTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateDateAndTime(6, 1, 2023), 
                TestHelper.GenerateDateAndTime(8, 1, 2023, 23, 59))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateDateAndTime(6, 1, 2023, 1), 
                TestHelper.GenerateDateAndTime(9, 1, 2023))
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateDateAndTime(3, 1, 2023, 0, 1), 
                TestHelper.GenerateDateAndTime(4, 1, 2023, 23, 59))
        };
    }
}