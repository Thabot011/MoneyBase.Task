using MassTransit;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Persistence.Consumers
{
    public class StartSessionConsumer : IConsumer<StartSessionCommand>
    {
        private readonly IServiceManager _serviceManager;
        public StartSessionConsumer(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task Consume(ConsumeContext<StartSessionCommand> context)
        {
            bool isAssigned = await _serviceManager.ChatAssignmentService.AssignChatAsync(context.Message.ChatId, context.CancellationToken);
            await context.RespondAsync(new StartSessionResult(context.Message.ChatId, isAssigned));
        }
    }
}
