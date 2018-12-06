using ScheduledTask.Infrastructure.Task.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScheduledTask.Infrastructure
{
    public class TaskMethodRunner
    {
        List<System.Timers.Timer> TimerList = new List<System.Timers.Timer>();

        public void Run(object obj)
        {
            var methods = Assembly.GetExecutingAssembly().GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(TaskMethodAttribute), false).Length > 0)
                      .ToArray();

            foreach (var method in methods)
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(delegate ()
                {
                    System.Timers.Timer Timer = new System.Timers.Timer();
                    Timer.Interval = GetIntervalMinute(method) * 60000;
                    Timer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
                    {
                        Timer.Enabled = false;
                        method.Invoke(obj, null);
                        Timer.Enabled = true;
                    };
                    Timer.Start();
                    TimerList.Add(Timer);
                }
                )).Start();
            }
        }

        private int GetIntervalMinute(MethodInfo method)
        {
            TaskMethodAttribute attribute = (TaskMethodAttribute)method.GetCustomAttributes(typeof(TaskMethodAttribute), true)[0];
            return attribute.IntervalMinute;
        }

    }
}
