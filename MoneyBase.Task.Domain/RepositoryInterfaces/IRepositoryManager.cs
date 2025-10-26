namespace MoneyBase.Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        IChatRepository ChatRepository { get; }
        IAgentRepository AgentRepository { get; }
        ITeamRepository TeamRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
