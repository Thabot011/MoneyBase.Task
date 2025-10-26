using MoneyBase.Domain.Entities;

namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface IChatRepository
    {
        Task<Chat> AddChatAsync(Chat chat, CancellationToken cancellationToken = default);
        Task UpdateLastPollDate(Chat chat, CancellationToken cancellationToken = default);
        Task<Chat> ChangeStatus(Chat chat, ChatStatus chatStatus, Guid agentId, CancellationToken cancellationToken = default);
        Task<Chat> GetChatById(Guid chatId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Chat>> GetActiveChatsAsync(CancellationToken cancellationToken = default);
    }
}
