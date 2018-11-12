using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ScheduledTask.Infrastructure;
using ScheduledTask.Infrastructure.Task;


namespace ScheduledTask.Win.TestService
{
    static class Program
    {
        static void Main()
        {
            WindowsService windowsService = new WindowsService();
            //windowsService.ServiceName = "DenemeWindowsService";
            windowsService.TaskList.Add(new FiveMinutesTask());
            windowsService.TaskList.Add(new At15OClockTask());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                windowsService
            };
            ServiceBase.Run(ServicesToRun);
        }

        public static void WriteLog(string Message)
        {
            if (!Directory.Exists(@"C:\\Log"))
            {
                Directory.CreateDirectory(@"C:\\Log");
            }
            if (!File.Exists(@"C:\\Log\\Log.txt"))
            {
                File.Create(@"C:\\Log\\Log.txt").Close();
            }
            File.WriteAllText(@"C:\\Log\\Log.txt", Message);
        }

    }

    public class FiveMinutesTask : MinutelyTask
    {
        public override int Interval => 5;

        public override void Run()
        {
            Program.WriteLog("FiveMinutesTask : " + DateTime.Now);
        }
    }

    public class At15OClockTask : HourlyTask
    {
        public override List<int> Hours => new List<int> { 15 };
        public override List<int> Minutes => new List<int> { 0, 30 };

        public override void Run()
        {
            Program.WriteLog("At15OClockTask : " + DateTime.Now);
        }
    }
}
