using Microsoft.Extensions.Hosting;
using MoneyBase.BackGroundService.Jobs;
using Quartz;

namespace MoneyBase.BackGroundService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // 🔹 Add Quartz
        services.AddQuartz(q =>
        {
            // Register job
            var jobKey = new JobKey("ChatPollingJob");
            q.AddJob<ChatPollingJob>(opts => opts.WithIdentity(jobKey));

            // Schedule it with a trigger (every 10 seconds)
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("ChatPollingJob-trigger")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever()));

            q.UseDefaultThreadPool(tp => { tp.MaxConcurrency = 3; });

        });

        // 🔹 Quartz Hosted Service (runs in background)
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });
    })
    .RunConsoleAsync();
        }
    }
}
