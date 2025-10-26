using MoneyBase.Contracts.Team;

namespace MoneyBase.Contracts.Shift
{
    public class ShiftDto : BaseDto
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public ShiftType ShiftType { get; set; }
        public ICollection<TeamDto> Teams { get; set; }
    }

    public enum ShiftType
    {
        Morning,
        Afternoon,
        Night,
        Overflow
    }
}
