using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoneyBase.Services.Abstractions;
using MoneyBase.Shared;
using Quartz;
using System.Threading;

namespace MoneyBase.BackGroundService.Jobs
{
    [DisallowConcurrentExecution]
    public class ChatMonitorJob : IJob
    {
        private readonly IOptions<MoneyBaseSettings> _options;
        private readonly ILogger<ChatMonitorJob> _logger;
        private readonly IServiceManager _serviceManager;
        public ChatMonitorJob(IOptions<MoneyBaseSettings> options, IServiceManager serviceManager, ILogger<ChatMonitorJob> logger)
        {
            _options = options;
            _serviceManager = serviceManager;
            _logger = logger;

        }
        public async Task Execute(IJobExecutionContext context)
        {
            var ct = context.CancellationToken;
            var threshold = _options.Value.PollMissThresholdSeconds;
            var now = DateTime.UtcNow;

            try
            {
                var active = await _serviceManager.ChatService.GetActiveChatsAsync(ct);
                foreach (var s in active)
                {
                    if (s.LastPollAt.HasValue &&
                        (now - s.LastPollAt.Value).TotalSeconds > threshold)
                    {

                        await _serviceManager.ChatService.ChangeStatus(s, Contracts.Chat.ChatStatus.Inactive, s.AgentId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Quartz MonitorJob error");
            }
        }
    }
}
