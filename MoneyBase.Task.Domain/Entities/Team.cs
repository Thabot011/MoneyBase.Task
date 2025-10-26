namespace MoneyBase.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string TeamName { get; set; }
        public ICollection<Agent> Agents { get; set; }
        public Shift Shift { get; set; }
        public Guid ShiftId { get; set; }
    }

}
