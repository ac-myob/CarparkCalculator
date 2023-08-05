using CarparkCalculator.Models;

namespace CarparkCalculator.Application;

public interface ICarparkService
{ 
    CarparkExpense GetCost(CarparkDuration carparkDuration);
}