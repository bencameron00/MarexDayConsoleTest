using MarexDayTest;

internal class Program
{
    private static void Main(string[] args)
    {
        DayChecker dc = new(new LongRunningLib(), TimeProvider.System);
        Console.Write(dc.CheckDay());
    }
}
