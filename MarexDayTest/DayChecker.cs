using MarexDayTest.Interfaces;

namespace MarexDayTest
{
    internal class DayChecker
    {
        private ILongRunningLib _longRunningLib;
        private TimeProvider _timeProvider;
        public DayChecker(ILongRunningLib longRunningLib, TimeProvider timeProvider)
        {
            _longRunningLib = longRunningLib;
            _timeProvider = timeProvider;
        }

        internal DayOfWeek? CheckDay()
        {
            DateTimeOffset now = _timeProvider.GetLocalNow();
            if (now.DayOfWeek == DayOfWeek.Wednesday)
            {
                return null;
            }

            Console.Write($"{now.DayOfWeek}");

            _longRunningLib.SomeLongRunningThirdPartyTask();

            return now.DayOfWeek;
           }
    }

    public class LongRunningLib : ILongRunningLib
    {
       public void SomeLongRunningThirdPartyTask()
        {
         Thread.Sleep(5000);
        }
    }
}
