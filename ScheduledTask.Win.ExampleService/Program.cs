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

namespace ScheduledTask.Win.ExampleService
{
    static class Program
    {
        static void Main()
        {
            WindowsService windowsService = new WindowsService();
            windowsService.TaskList.Add(new Examples.ExampleMinutelyTask());
            windowsService.TaskList.Add(new Examples.ExampleTenOClockOnFridayTask());

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                windowsService
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
