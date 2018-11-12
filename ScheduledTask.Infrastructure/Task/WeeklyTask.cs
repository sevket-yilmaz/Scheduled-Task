using System;
using System.Collections.Generic;

namespace ScheduledTask.Infrastructure.Task
{
    public abstract class WeeklyTask : HourlyTask
    {
        public abstract List<DayOfWeek> Days { get; }

        public override bool ItsTime => this.Days.Contains(DateTime.Now.DayOfWeek) && base.ItsTime;
    }
}
