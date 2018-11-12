using ScheduledTask.Infrastructure.Task;
using System;
using System.Collections.Generic;

namespace ScheduledTask.Infrastructure
{
    public class FiveMinutesTask : MinutelyTask
    {
        public override int Interval => 5;

        public override void Run()
        {
            Console.WriteLine("FiveMinutesTask : " + DateTime.Now);
        }
    }

    public class At12OClockTask : HourlyTask
    {
        public override List<int> Hours => new List<int> { 12 };
        public override List<int> Minutes => new List<int> { 0, 10 };

        public override void Run()
        {
            Console.WriteLine("At12OClockTask : " + DateTime.Now);
        }
    }

    public class FridayAtTenOclocktask : WeeklyTask
    {
        public override List<DayOfWeek> Days => new List<DayOfWeek> { DayOfWeek.Friday };
        public override List<int> Hours => new List<int> { 11 };

        public override void Run()
        {
            Console.WriteLine("FridayAtTenOclocktask : " + DateTime.Now);
        }
    }

    public class TheLastDayOfMonth : MonthlyTask
    {
        public override List<int> Days => null;
        public override List<int> Hours => new List<int> { 20 };
        public override bool RunLastDayOfMonth => true;
        public override void Run()
        {
            Console.WriteLine("TheFirstDayOfMonth : " + DateTime.Now);
        }
    }
}
