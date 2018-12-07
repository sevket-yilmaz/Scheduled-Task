# Scheduled Task Library


### How to use?

- Create a new Windows Service project
- Import the **Scheduled Task Library** to your project
- Create a new task class 
  

```csharp
using ScheduledTask.Infrastructure.Task;
public class ExampleFiveMinutesTask : MinutelyTask
{
    public override int Interval => 5;

    public override void Run()
    {
        // Do something
    }
}
```

- Delete auto generated Service1 class and clear Main method of Program class
- Create a new **ScheduledTask.Infrastructure.WindowsService** instance in Main method of Program class and add your task to task list

```csharp
static class Program
{
    static void Main()
    {
        WindowsService windowsService = new WindowsService();
        windowsService.TaskList.Add(new ExampleFiveMinutesTask());
        //windowsService.TaskList.Add(new AnotherTask1());
        //windowsService.TaskList.Add(new AnotherTask2());
        //...
        
        ServiceBase[] ServicesToRun;
        ServicesToRun = new ServiceBase[]
        {
            windowsService
        };
        ServiceBase.Run(ServicesToRun);
    }
}
```

> See **ScheduledTask.Win.ExampleService** project for examples

- Add a new class inherited from **ScheduledTask.Infrastructure.WindowsServiceInstaller** 

```csharp
[RunInstaller(true)]   //Important
public class CustomServiceInstaller : WindowsServiceInstaller
{
    public CustomServiceInstaller() : base()
    {
        this.serviceInstaller.ServiceName = "YourServiceName";
        this.serviceInstaller.DisplayName = "Service Display Name";
        this.serviceInstaller.Description = "Your service description";
    }
}
```


### Installation

You can install service with Command Prompt in this way:

```
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe" "C:\YourPath\YourService.exe"
```
