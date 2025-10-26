using MoneyBase.Contracts.Agent;

namespace MoneyBase.Contracts.Chat
{
    public class ChatDto : BaseDto
    {
        public string Title { get; set; }
        public ChatStatus ChatStatus { get; set; }
        public AgentDto Agent { get; set; }
        public Guid AgentId { get; set; }
        public DateTimeOffset? LastPollAt { get; set; }

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
