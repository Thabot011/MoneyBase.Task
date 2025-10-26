using MoneyBase.Domain;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Database;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IChatRepository> _lazyChatRepository;
        private readonly Lazy<IAgentRepository> _lazyAgentRepository;
        private readonly Lazy<ITeamRepository> _lazyTeamRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyAgentRepository = new Lazy<IAgentRepository>(() => new AgentRepository(dbContext));
            _lazyChatRepository = new Lazy<IChatRepository>(() => new ChatRepository(dbContext));
            _lazyTeamRepository = new Lazy<ITeamRepository>(() => new TeamRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));

        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IChatRepository ChatRepository => _lazyChatRepository.Value;

        public IAgentRepository AgentRepository => _lazyAgentRepository.Value;

        public ITeamRepository TeamRepository => _lazyTeamRepository.Value;
    }
}
