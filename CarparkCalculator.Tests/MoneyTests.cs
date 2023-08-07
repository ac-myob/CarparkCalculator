using CarparkCalculator.Models;

namespace CarparkCalculator.Tests;

public class MoneyTests
{
    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_GivenMoneyAmountIsNegative()
    {
        const decimal negativeMoneyAmount = -1.00m;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Money(negativeMoneyAmount));
    }
    
    [Theory]
    [InlineData(10.50, 10.50)]
    [InlineData(10.501, 10.50)]
    [InlineData(10.506, 10.51)]
    [InlineData(10.505, 10.51)]
    [InlineData(10.5049, 10.50)]
    public void Constructor_RoundsMoneyAmountTo2DecimalPlaces_GivenNonNegativeMoneyAmount(
        decimal moneyAmount, decimal expectedRoundedMoneyAmount)
    {
        var money = new Money(moneyAmount);

        var actualRoundedMoneyAmount = money.Amount;

        actualRoundedMoneyAmount.Should().Be(expectedRoundedMoneyAmount);
    }
}