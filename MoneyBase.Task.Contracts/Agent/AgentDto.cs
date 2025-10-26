using MoneyBase.Contracts.Chat;

namespace MoneyBase.Contracts.Agent
{
    public class AgentDto : BaseDto
    {
        public AgentType AgentType { get; set; }
        public List<ChatDto> Chats { get; set; }
    }
}
