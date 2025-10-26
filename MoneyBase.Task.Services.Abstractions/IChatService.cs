using MoneyBase.Contracts.Chat;

namespace MoneyBase.Services.Abstractions
{
    public interface IChatService
    {
        Task AddChatAsync(AddChatDto chat, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatDto>> GetChatsAsync(CancellationToken cancellationToken = default);
        Task AssignChat(ChatDto chat, CancellationToken cancellationToken = default);

    }
}
