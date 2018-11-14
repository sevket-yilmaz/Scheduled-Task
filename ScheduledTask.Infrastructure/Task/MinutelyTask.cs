using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace ScheduledTask.Infrastructure.Task
{
    public abstract class MinutelyTask : IScheduledTask
    {
        public abstract int Interval { get; }
        public virtual bool ItsTime { get; } = true;
        public abstract void Run();

        private System.Timers.Timer Timer { get; set; }

        public void Initialize()
        {
            this.Timer = new System.Timers.Timer();
            this.Timer.Interval = this.Interval * 60000;
            this.Timer.Elapsed += Timer_Elapsed;
            this.Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.ItsTime)
            {
                //TODO bunu Minutly de değil de üst seviyede işlemek lazım 
                new Thread(new ThreadStart(
                    delegate ()
                    {
                        try
                        {
                            Run();
                        }
                        catch (System.Exception ex)
                        {
                            // TODO
                            using (EventLog eventLog = new EventLog("Application"))
                            {
                                eventLog.Source = "Application";
                                eventLog.WriteEntry("Exception: " + ex.Message, EventLogEntryType.Error, 101, 1);
                                eventLog.WriteEntry("InnerException: " + ex.InnerException?.Message, EventLogEntryType.Error, 101, 1);
                            }
                        }
                    }
                    )).Start();
            }
        }
    }

}
