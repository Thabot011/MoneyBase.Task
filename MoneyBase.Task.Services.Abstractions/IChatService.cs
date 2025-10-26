using MoneyBase.Contracts.Chat;

namespace MoneyBase.Services.Abstractions
{
    public interface IChatService
    {
        Task<ChatDto> AddChatAsync(AddChatDto chat, CancellationToken cancellationToken = default);
        Task UpdateLastPollDate(ChatDto chat, CancellationToken cancellationToken = default);
        Task<ChatDto> ChangeStatus(ChatDto chat, ChatStatus chatStatus, Guid agentId, CancellationToken cancellationToken = default);
        Task<ChatDto> GetChatById(Guid chatId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatDto>> GetActiveChatsAsync(CancellationToken cancellationToken = default);

    }
}
