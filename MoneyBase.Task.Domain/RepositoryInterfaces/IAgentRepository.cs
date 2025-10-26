using MoneyBase.Domain.Entities;

namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface IAgentRepository
    {
        Task AssignChatsToAgent(Agent agent, IEnumerable<Chat> chats, CancellationToken cancellationToken = default);
    }
}
