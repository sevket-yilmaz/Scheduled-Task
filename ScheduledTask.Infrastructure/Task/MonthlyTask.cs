using System;
using System.Collections.Generic;

namespace ScheduledTask.Infrastructure.Task
{
    public abstract class MonthlyTask : HourlyTask
    {
        public abstract List<int> Days { get; }
        public virtual bool RunLastDayOfMonth { get; } = false;

        public override bool ItsTime
        {
            get
            {
                if (!RunLastDayOfMonth)
                {
                    return this.Days.Contains(DateTime.Now.Day) && base.ItsTime;
                }
                else
                {
                    return DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) == DateTime.Now.Day && base.ItsTime;
                }
            }
        }
    }
}
