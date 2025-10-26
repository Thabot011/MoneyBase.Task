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
        private readonly IOptions<MoneyBaseSettings> _options;
        public ChatRepository(RepositoryDbContext dbContext, IOptions<MoneyBaseSettings> options)
        {
            _dbContext = dbContext;
            _options = options;
        }
        public async Task AddChatAsync(Chat chat, CancellationToken cancellationToken = default)
        {
            await _dbContext.Chats.AddAsync(chat, cancellationToken);
        }

        public async Task<IEnumerable<Chat>> GetChatsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Chats.Where(c => c.ChatStatus == ChatStatus.Queued).ToListAsync(cancellationToken);
        }

        public Task AssignChat(Chat chat, CancellationToken cancellationToken = default)
        {
            chat.ChatStatus = ChatStatus.Assigned;
            _dbContext.Chats.Update(chat);
            return Task.CompletedTask;
        }
    }
}
