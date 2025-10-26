namespace MoneyBase.Domain.Entities
{
    public class Agent : BaseEntity
    {
        public AgentType AgentType { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public Team Team { get; set; }
        public Guid TeamId { get; set; }
    }

    public enum AgentType
    {
        Junior,
        MidLevel,
        Senior,
        TeamLead
    }
}
