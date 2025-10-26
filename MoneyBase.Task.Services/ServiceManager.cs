using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IChatService> _lazyChatService;
        private readonly Lazy<IAgentService> _lazyAgentService;
        private readonly Lazy<ITeamService> _lazyTeamService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyAgentService = new Lazy<IAgentService>(() => new AgentService(repositoryManager));
            _lazyChatService = new Lazy<IChatService>(() => new ChatService(repositoryManager));
            _lazyTeamService = new Lazy<ITeamService>(() => new TeamService(repositoryManager));
        }
        public IChatService ChatService => _lazyChatService.Value;
        public IAgentService AgentService => _lazyAgentService.Value;
        public ITeamService TeamService => _lazyTeamService.Value;
    }
}
