namespace MoneyBase.Domain.Entities
{
    public class Shift : BaseEntity
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public ShiftType ShiftType { get; set; }
        public ICollection<Team> Teams { get; set; }
    }

    public enum ShiftType
    {
        Morning,
        Afternoon,
        Night,
        Overflow
    }
}
