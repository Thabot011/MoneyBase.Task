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

        public async Task AddChatAsync(AddChatDto chat, CancellationToken cancellationToken = default)
        {
            var chatEntity = chat.Adapt<Chat>();
            await _repositoryManager.ChatRepository.AddChatAsync(chatEntity, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ChatDto>> GetChatsAsync(CancellationToken cancellationToken = default)
        {
            var chats = await _repositoryManager.ChatRepository.GetChatsAsync(cancellationToken);
            var chatsDto = chats.Adapt<IEnumerable<ChatDto>>();
            return chatsDto;
        }

        public async Task AssignChat(ChatDto chat, CancellationToken cancellationToken = default)
        {
            var chatEntity = chat.Adapt<Chat>();
            await _repositoryManager.ChatRepository.AssignChat(chatEntity, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
