using System.Collections.Generic;

namespace ScheduledTask.Infrastructure
{
    public class WindowsService : System.ServiceProcess.ServiceBase
    {
        public List<Task.IScheduledTask> TaskList = new List<Task.IScheduledTask>();


        public WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            foreach (var task in TaskList)
            {
                task.Initialize();
            }
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "ScheduledTaskWindowsService";
        }

    }
}
