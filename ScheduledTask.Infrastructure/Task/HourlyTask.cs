using System;
using System.Collections.Generic;

namespace ScheduledTask.Infrastructure.Task
{

    public abstract class HourlyTask : MinutelyTask
    {
        public abstract List<int> Hours { get; }
        public virtual List<int> Minutes => new List<int>() { 0 };
        public sealed override int Interval => 1;

        public override bool ItsTime => Minutes.Contains(DateTime.Now.Minute) && Hours.Contains(DateTime.Now.Hour);
    }

}