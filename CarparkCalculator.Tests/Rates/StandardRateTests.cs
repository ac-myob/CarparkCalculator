using CarparkCalculator.Application.Rates;
using CarparkCalculator.Models;

namespace CarparkCalculator.Tests.Rates;

public class StandardRateTests
{
    private readonly StandardRate _standardRate = new();
    
    [Theory]
    [MemberData(nameof(CarparkDurationUnder1HourTestData))]
    [MemberData(nameof(CarparkDurationUnder2HoursTestData))]
    [MemberData(nameof(CarparkDurationUnder3HoursTestData))]
    [MemberData(nameof(CarparkDurationOver3HoursTestData))]
    public void CalculateCost_ReturnsCorrectMoneyAmount_GivenVaryingCarparkDurations(
        CarparkDuration carparkDuration, decimal expectedMoneyAmount)
    {
        var actualMoneyAmount = _standardRate.CalculateCost(carparkDuration).Amount;

        actualMoneyAmount.Should().Be(expectedMoneyAmount);
    }

    private static IEnumerable<object[]> CarparkDurationUnder1HourTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(9, 30)),
            2.50m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(10)), 
            5.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(9, 1)), 
            0.08m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9, 59), TestHelper.GenerateTime(10)), 
            0.08m
        };
    }
    
    private static IEnumerable<object[]> CarparkDurationUnder2HoursTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(10, 30)),
            15.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(11)), 
            20.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9), TestHelper.GenerateTime(10, 1)), 
            10.17m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(9, 59), TestHelper.GenerateTime(11)), 
            10.17m
        };
    }
    
    private static IEnumerable<object[]> CarparkDurationUnder3HoursTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(0), TestHelper.GenerateTime(2, 30)),
            37.50m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(0), TestHelper.GenerateTime(3)), 
            45.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(0), TestHelper.GenerateTime(2, 1)), 
            30.25m
        };
        
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(0, 59), TestHelper.GenerateTime(3)), 
            30.25m
        };
    }

    private static IEnumerable<object[]> CarparkDurationOver3HoursTestData()
    {
        yield return new object[]
        {
            new CarparkDuration(TestHelper.GenerateTime(0), TestHelper.GenerateTime(4, 30)),
            20.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(31, 12, 2000, 5, 59), 
                TestHelper.GenerateDateAndTime(2, 1, 2001, 2)), 
            60.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(1, 1, 2000, 20), 
                TestHelper.GenerateDateAndTime(2, 1, 2000)), 
            40.00m
        };
        
        yield return new object[]
        {
            new CarparkDuration(
                TestHelper.GenerateDateAndTime(1, 1, 2000, 21), 
                TestHelper.GenerateDateAndTime(2, 1, 2000, 0, 1)), 
            40.00m
        };
    }
}