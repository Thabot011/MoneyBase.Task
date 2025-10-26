using MoneyBase.Contracts.Agent;
using MoneyBase.Contracts.Shift;

namespace MoneyBase.Contracts.Team
{
    public class TeamDto: BaseDto
    {
        public string TeamName { get; set; }
        public ICollection<AgentDto> Agents { get; set; }
        public ShiftDto Shift { get; set; }
        public Guid ShiftId { get; set; }

    }
    public enum ShiftType
    {
        Morning,
        Afternoon,
        Night
    }
}
