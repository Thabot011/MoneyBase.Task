namespace MoneyBase.Services.Abstractions
{
    public interface IServiceManager
    {
        IChatService ChatService { get; }
        IAgentService AgentService { get; }
        ITeamService TeamService { get; }
    }
}
