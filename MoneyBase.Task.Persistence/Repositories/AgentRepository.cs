using Microsoft.EntityFrameworkCore;
using MoneyBase.Contracts.Chat;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;

namespace MoneyBase.Persistence.Repositories
{
    internal sealed class AgentRepository : IAgentRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public AgentRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
    }
}
