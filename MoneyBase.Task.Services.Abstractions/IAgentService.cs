using MoneyBase.Contracts.Agent;
using MoneyBase.Contracts.Chat;

namespace MoneyBase.Services.Abstractions
{
    public interface IAgentService
    {
        Task AssignChatsToAgent(AgentDto agent, List<ChatDto> chats, CancellationToken cancellationToken = default);

    }
}
