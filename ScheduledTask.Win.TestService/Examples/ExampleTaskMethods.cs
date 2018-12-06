using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduledTask.Infrastructure.Task.Attribute;

namespace ScheduledTask.Win.ExampleService.Examples
{
    public class ExampleTaskMethods
    {
        [TaskMethod]
        public void ExampleTaskMethod1()
        {
            // do something
            LogWriter.WriteLog("ExampleTaskMethod1 : " + DateTime.Now);
        }

        [TaskMethod(15)]
        public void ExampleTaskMethod2()
        {
            // do something
            LogWriter.WriteLog("ExampleTaskMethod2 : " + DateTime.Now);
        }

        [TaskMethod(30)]
        public void ExampleTaskMethod3()
        {
            // do something
            LogWriter.WriteLog("ExampleTaskMethod3 : " + DateTime.Now);
        }
    }
}
