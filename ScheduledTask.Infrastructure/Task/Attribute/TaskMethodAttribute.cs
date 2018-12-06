using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTask.Infrastructure.Task.Attribute
{
    public class TaskMethodAttribute : System.Attribute
    {
        public int IntervalMinute { get; set; }
        public TaskMethodAttribute()
        {
            this.IntervalMinute = 5;
        }

        public TaskMethodAttribute(int Interval)
        {
            this.IntervalMinute = Interval;
        }
    }
}
