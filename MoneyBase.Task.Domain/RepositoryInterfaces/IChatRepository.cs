using MoneyBase.Domain.Entities;

namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface IChatRepository
    {
        Task AddChatAsync(Chat chat, CancellationToken cancellationToken = default);
        Task<IEnumerable<Chat>> GetChatsAsync(CancellationToken cancellationToken = default);
        Task AssignChat(Chat chat, CancellationToken cancellationToken = default);
    }
}
