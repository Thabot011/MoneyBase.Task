using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;
using MoneyBase.Shared;
using System.Runtime;

namespace MoneyBase.Persistence.Repositories
{
    internal sealed class ChatRepository : IChatRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public ChatRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Chat> AddChatAsync(Chat chat, CancellationToken cancellationToken = default)
        {
            var chatAdded = await _dbContext.Chats.AddAsync(chat, cancellationToken);
            return chatAdded.Entity;
        }

        public async Task UpdateLastPollDate(Chat chat, CancellationToken cancellationToken = default)
        {
            var local = _dbContext.Set<Chat>().Local.FirstOrDefault(x => x.Id == chat.Id);
            if (local != null)
                _dbContext.Entry(local).State = EntityState.Detached;

            // Attach and only update the needed property
            _dbContext.Attach(chat);
            chat.LastPollAt = DateTimeOffset.UtcNow;
            _dbContext.Entry(chat).Property(x => x.LastPollAt).IsModified = true;
            await Task.CompletedTask;
        }

        public Task<Chat> ChangeStatus(Chat chat, ChatStatus chatStatus, Guid agentId, CancellationToken cancellationToken = default)
        {
            // Prevent duplicate tracking
            var local = _dbContext.Set<Chat>().Local.FirstOrDefault(x => x.Id == chat.Id);
            if (local != null)
                _dbContext.Entry(local).State = EntityState.Detached;

            // Attach and only update the needed property
            _dbContext.Attach(chat);
            chat.ChatStatus = chatStatus;
            chat.AgentId = agentId;
            _dbContext.Entry(chat).Property(x => x.ChatStatus).IsModified = true;
            _dbContext.Entry(chat).Property(x => x.AgentId).IsModified = true;
            return Task.FromResult(chat);
        }

        public async Task<Chat> GetChatById(Guid chatId, CancellationToken cancellationToken = default)
        {
            var chat = await _dbContext.Chats.FirstOrDefaultAsync(c => c.Id == chatId, cancellationToken);
            return chat;
        }

        public async Task<IEnumerable<Chat>> GetActiveChatsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Chats.Where(c => c.ChatStatus != ChatStatus.Inactive).AsNoTracking().ToListAsync();
        }
    }
}
