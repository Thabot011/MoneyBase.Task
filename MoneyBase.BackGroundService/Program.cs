using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoneyBase.BackGroundService.Jobs;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;
using MoneyBase.Persistence.Repositories;
using MoneyBase.Services;
using MoneyBase.Services.Abstractions;
using MoneyBase.Shared;
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
            q.AddJob<ChatMonitorJob>(opts => opts.WithIdentity(jobKey));

            // Schedule it with a trigger (every 10 seconds)
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("ChatPollingJob-trigger")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever()));


        });

        // 🔹 Quartz Hosted Service (runs in background)
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        services.Configure<MoneyBaseSettings>(hostContext.Configuration.GetSection("MoneyBaseSettings"));

        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddDbContext<RepositoryDbContext>(options =>
options.UseSqlServer(hostContext.Configuration.GetConnectionString("Database")));

    })
    .RunConsoleAsync();
        }
    }
}
