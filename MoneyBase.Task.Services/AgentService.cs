using Mapster;
using MoneyBase.Contracts.Agent;
using MoneyBase.Contracts.Chat;
using MoneyBase.Domain.Entities;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Services.Abstractions;

namespace MoneyBase.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AgentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

    }
}
