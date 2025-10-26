using MassTransit;

namespace MoneyBase.Persistence.Consumers
{
    public class StartSessionConsumer : IConsumer<StartSession>
    {
        public StartSessionConsumer()
        {

        }
        public Task Consume(ConsumeContext<StartSession> context)
        {
        }
    }
}
