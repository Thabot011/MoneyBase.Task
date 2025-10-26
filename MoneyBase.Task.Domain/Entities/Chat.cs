namespace MoneyBase.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string Title { get; set; }
        public ChatStatus ChatStatus { get; set; }
        public Agent Agent { get; set; }
        public Guid AgentId { get; set; }

    }

    public enum ChatStatus
    {
        Queued,
        Assigned,
        Active,
        Inactive,
        Refused,
    }
}
