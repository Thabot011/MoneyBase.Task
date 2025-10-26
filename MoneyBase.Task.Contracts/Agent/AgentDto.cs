using MoneyBase.Contracts.Chat;
using MoneyBase.Contracts.Team;

namespace MoneyBase.Contracts.Agent
{
    public class AgentDto : BaseDto
    {
        public AgentType AgentType { get; set; }
        public ICollection<ChatDto> Chats { get; set; }
        public TeamDto Team { get; set; }
        public Guid TeamId { get; set; }
        public int MaxChats { get; set; }
    }
}
