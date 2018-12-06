using ScheduledTask.Infrastructure.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScheduledTask.Win.ExampleService.Examples
{
    public class ExampleMinutelyTask : MinutelyTask
    {
        public override int Interval => 1;

        public override void Run()
        {
            LogWriter.WriteLog("ExampleMinutelyTask : " + DateTime.Now);
        }
    }

    public class ExampleHourlyTask : HourlyTask
    {
        public override List<int> Hours => new List<int> { 8, 15 };
        public override List<int> Minutes => new List<int> { 4, 8, 11, 15 };

        public override void Run()
        {
            LogWriter.WriteLog("ExampleHourlyTask : " + DateTime.Now);
        }
    }

    public class ExampleFiveMinutesTask : MinutelyTask
    {
        public override int Interval => 5;

        public override void Run()
        {
            LogWriter.WriteLog("ExampleFiveMinutesTask : " + DateTime.Now);
        }
    }

    public class ExampleAt12OClockTask : HourlyTask
    {
        public override List<int> Hours => new List<int> { 12 };
        public override List<int> Minutes => new List<int> { 0, 30 };

        public override void Run()
        {
            LogWriter.WriteLog("ExampleAt12OClockTask : " + DateTime.Now);
        }
    }

    public class ExampleTenOClockOnFridayTask : WeeklyTask
    {
        public override List<DayOfWeek> Days => new List<DayOfWeek> { DayOfWeek.Friday };
        public override List<int> Hours => new List<int> { 11 };

        public override void Run()
        {
            LogWriter.WriteLog("ExampleTenOClockOnFridayTask : " + DateTime.Now);
        }
    }

    public class ExampleTheLastDayOfMonth : MonthlyTask
    {
        public override List<int> Days => null;
        public override List<int> Hours => new List<int> { 20 };
        public override bool RunLastDayOfMonth => true;
        public override void Run()
        {
            LogWriter.WriteLog("ExampleTheLastDayOfMonth : " + DateTime.Now);
        }
    }

    public class LogWriter
    {

        private static object LockObject = new object();
        public static void WriteLog(string Message)
        {
            string FolderPath = @"C:\\Log";
            string FilePath = FolderPath + "\\Log.txt";

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();

            lock (LockObject)
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                    writer.WriteLine(Message + Environment.NewLine);
        }
    }
}
