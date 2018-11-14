using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ScheduledTask.Infrastructure;
using ScheduledTask.Infrastructure.Task;
using System.ComponentModel;

namespace ScheduledTask.Win.TestService
{
    static class Program
    {
        static void Main()
        {
            WindowsService windowsService = new WindowsService();
            windowsService.ServiceName = "TestScheduledTaskService";
            windowsService.TaskList.Add(new OneMinuteTask());
            windowsService.TaskList.Add(new At11OClockTask());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                windowsService
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static object LockObject = new object();
        public static void WriteLog(string Message)
        {
            if (!Directory.Exists(@"C:\\Log"))
                Directory.CreateDirectory(@"C:\\Log");

            if (!File.Exists(@"C:\\Log\\Log.txt"))
                File.Create(@"C:\\Log\\Log.txt").Close();

            lock (LockObject)
                using (StreamWriter writer = new StreamWriter(@"C:\\Log\\Log.txt", true))
                    writer.WriteLine(Message + Environment.NewLine);
        }
    }

    public class OneMinuteTask : MinutelyTask
    {
        public override int Interval => 1;

        public override void Run()
        {
            Program.WriteLog("OneMinuteTask : " + DateTime.Now);
        }
    }

    public class At11OClockTask : HourlyTask
    {
        public override List<int> Hours => new List<int> { 12 };
        public override List<int> Minutes => new List<int> { 4, 8, 11, 15 };

        public override void Run()
        {
            Program.WriteLog("At11OClockTask : " + DateTime.Now);
        }
    }

    [RunInstaller(true)]
    public class Installer : WindowsServiceInstaller
    {
        public Installer() : base()
        {
            this.serviceInstaller.ServiceName = "TestScheduledTaskService";
            this.serviceInstaller.DisplayName = "Test Scheduled Task Windows Service";
            this.serviceInstaller.Description = "A test windows service for scheduled tasks...";
        }
    }
}
