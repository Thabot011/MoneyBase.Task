using Mapster;
using MoneyBase.Contracts.Chat;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public class ChatService : IChatService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ChatService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<ChatDto> AddChatAsync(AddChatDto chat, CancellationToken cancellationToken = default)
        {
            var chatEntity = chat.Adapt<Chat>();
            chatEntity = await _repositoryManager.ChatRepository.AddChatAsync(chatEntity, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return chatEntity.Adapt<ChatDto>();
        }

        public async Task<ChatDto> ChangeStatus(ChatDto chat, Contracts.Chat.ChatStatus chatStatus, Guid agentId, CancellationToken cancellationToken = default)
        {
            var chatEntity = chat.Adapt<Chat>();
            var updatedEntity = await _repositoryManager.ChatRepository.ChangeStatus(chatEntity, (Domain.Entities.ChatStatus)chatStatus, agentId, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return updatedEntity.Adapt<ChatDto>();
        }

        public async Task<IEnumerable<ChatDto>> GetActiveChatsAsync(CancellationToken cancellationToken = default)
        {
            var chats = await _repositoryManager.ChatRepository.GetActiveChatsAsync(cancellationToken);
            return chats.Adapt<IEnumerable<ChatDto>>();
        }

        public async Task<ChatDto> GetChatById(Guid chatId, CancellationToken cancellationToken = default)
        {
            var chat = await _repositoryManager.ChatRepository.GetChatById(chatId, cancellationToken);
            return chat.Adapt<ChatDto>();
        }

        public async Task UpdateLastPollDate(ChatDto chat, CancellationToken cancellationToken = default)
        {
            var chatEntity = chat.Adapt<Chat>();
            await _repositoryManager.ChatRepository.UpdateLastPollDate(chatEntity, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
