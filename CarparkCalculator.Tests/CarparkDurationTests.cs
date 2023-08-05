using CarparkCalculator.Models;

namespace CarparkCalculator.Tests;

public class CarparkDurationTests
{
    [Fact]
    public void CarparkDurartionConstructor_ShouldThrowInvalidDateException_GivenEntryDateIsBeforeExitDate()
    {
        var entryDate = new DateTime(2000, 01, 15);
        var exitDate = new DateTime(2000, 01, 1);
        Assert.Throws<InvalidDateException>(() => new CarparkDuration(entryDate, exitDate));
    }
}