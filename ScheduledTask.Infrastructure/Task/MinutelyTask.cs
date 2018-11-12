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
                new Thread(new ThreadStart(Run)).Start();
            }
        }
    }

}
