using ScheduledTask.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTask.Win.ExampleService
{
    [RunInstaller(true)]
    public class CustomServiceInstaller : WindowsServiceInstaller
    {
        public CustomServiceInstaller() : base()
        {
            this.serviceInstaller.ServiceName = "TestScheduledTaskService";
            this.serviceInstaller.DisplayName = "Test Scheduled Task Windows Service";
            this.serviceInstaller.Description = "A test windows service for scheduled tasks...";
        }
    }
}
