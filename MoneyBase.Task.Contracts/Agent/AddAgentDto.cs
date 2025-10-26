namespace MoneyBase.Contracts.Agent
{
    public class AddAgentDto
    {
        public AgentType AgentType { get; set; }
        public int AssignedChats { get; set; }
    }
    public enum AgentType
    {
        Junior,
        MidLevel,
        Senior,
        TeamLead
    }
}
