namespace CarparkCalculator.Tests;

public static class TestHelper
{
    public static DateTime GenerateTime(int hour = 0, int minute = 0)
    {
        return new DateTime(1, 1, 1, hour, minute, 0);
    }
    public static DateTime GenerateDateAndTime(int day, int month, int year, int hour = 0, int minute = 0)
    {
        return new DateTime(year, month, day, hour, minute, 0);
    }
}