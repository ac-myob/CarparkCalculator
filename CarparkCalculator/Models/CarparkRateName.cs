namespace CarparkCalculator.Models;

public enum CarparkRateName
{
    EarlyBird,
    NightRate,
    WeekendRate,
    StandardRate
}

public static class CarparkRateNameExtensions
{
    public static string GetString(this CarparkRateName carparkRateName)
    {
        return carparkRateName switch
        {
            CarparkRateName.EarlyBird => "Early bird",
            CarparkRateName.NightRate => "Night rate",
            CarparkRateName.WeekendRate => "Weekend rate",
            CarparkRateName.StandardRate => "Standard rate",
            _ => throw new ArgumentOutOfRangeException(nameof(carparkRateName), carparkRateName, null)
        };
    }
} 