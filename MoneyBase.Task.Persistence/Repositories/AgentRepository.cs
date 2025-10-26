using Microsoft.EntityFrameworkCore;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBase.Persistence.Repositories
{
    internal sealed class AgentRepository : IAgentRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public AgentRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public Task AssignChatsToAgent(Agent agent, IEnumerable<Chat> chats, CancellationToken cancellationToken = default)
        {
            agent.Chats = agent.Chats.Concat(chats).ToList();
            _dbContext.Agents.Update(agent);
            return Task.CompletedTask;
        }
    }
}
