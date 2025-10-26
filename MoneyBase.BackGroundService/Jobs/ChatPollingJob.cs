using Quartz;

namespace MoneyBase.BackGroundService.Jobs
{
    public class ChatPollingJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] SampleJob running...");
            return Task.CompletedTask;
        }
    }
}
