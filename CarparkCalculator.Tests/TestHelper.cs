namespace CarparkCalculator.Tests;

public static class TestHelper
{
    public static DateTime GenerateTime(int hour = 0, int minutes = 0)
    {
        return new DateTime(1, 1, 1, hour, minutes, 0);
    }
    public static DateTime GenerateDateAndTime(int day, int month, int year, int hour = 0, int minutes = 0)
    {
        return new DateTime(year, month, day, hour, minutes, 0);
    }
}