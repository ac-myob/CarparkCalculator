using CarparkCalculator.Application;
using CarparkCalculator.Models;
using CarparkCalculator.Presentation;
using Moq;

namespace CarparkCalculator.Tests;

public class CarparkEngineTests
{
    private readonly Mock<IReader> _reader = new();
    private readonly Mock<IWriter> _writer = new();
    private readonly Mock<ICarparkService> _carparkService = new();
    private readonly CarparkEngine _carparkEngine;

    public CarparkEngineTests()
    {
        _carparkEngine = new CarparkEngine(_carparkService.Object, _reader.Object, _writer.Object);
    }

    [Fact]
    public void Run_DisplaysCorrectOutputMessages_GivenUserInputIsValid()
    {
        var expectedCarparkExpense = new CarparkExpense(CarparkRateName.StandardRate, new Money(100));
        _carparkService.Setup(_ => _.GetCost(It.IsAny<CarparkDuration>())).Returns(expectedCarparkExpense);
        _reader.Setup(_ => _.ReadDateTime()).Returns(It.IsAny<DateTime>());
        
        _carparkEngine.Run();
        
        _writer.Verify(_ => _.Write("Entry date: "), Times.Once);
        _writer.Verify(_ => _.Write("Please enter a date in the format of dd/mm/yy hh:mm: "), Times.Exactly(2));
        _writer.Verify(_ => _.Write("Exit date: "), Times.Once);
        _writer.Verify(_ => _.Write("Rate name: Standard rate\n"), Times.Once);
        _writer.Verify(_ => _.Write("Total cost: $100.00\n"), Times.Once);
    }
    
    [Fact]
    public void Run_DisplaysCorrectOutputMessages_GivenUserInputIsInvalid()
    {
        var expectedCarparkExpense = new CarparkExpense(CarparkRateName.StandardRate, new Money(100));
        _carparkService.Setup(_ => _.GetCost(It.IsAny<CarparkDuration>())).Returns(expectedCarparkExpense);
        _reader.SetupSequence(_ => _.ReadDateTime())
            .Returns((DateTime?) null)
            .Returns(TestHelper.GenerateTime())
            .Returns(TestHelper.GenerateTime())
            .Returns(TestHelper.GenerateTime());
        
        _carparkEngine.Run();
        
        _writer.Verify(_ => _.Write("Entry date: "), Times.Once);
        _writer.Verify(_ => _.Write("Invalid input. Please try again. "), Times.Once);
        _writer.Verify(_ => _.Write("Please enter a date in the format of dd/mm/yy hh:mm: "), Times.Exactly(3));
        _writer.Verify(_ => _.Write("Exit date: "), Times.Once);
        _writer.Verify(_ => _.Write("Rate name: Standard rate\n"), Times.Once);
        _writer.Verify(_ => _.Write("Total cost: $100.00\n"), Times.Once);
    }
}