using MoneyBase.Contracts.Agent;

namespace MoneyBase.Contracts.Team
{
    public class AddTeamDto
    {
        public string TeamName { get; set; }
        public List<AgentDto> Agents { get; set; }
        public ShiftType Shift { get; set; }
    }
}
