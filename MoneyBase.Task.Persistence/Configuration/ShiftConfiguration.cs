using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyBase.Domain.Entities;

namespace MoneyBase.Persistence.Configuration
{
    internal class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable(nameof(Shift));
            builder.HasKey(shift => shift.Id);
            builder.Property(shift => shift.Id).ValueGeneratedOnAdd();
            builder.Property(shift => shift.StartTime).IsRequired();
            builder.Property(shift => shift.EndTime).IsRequired();
            builder.Property(shift => shift.ShiftType).IsRequired();
            builder.HasMany(shift => shift.Teams).WithOne(team => team.Shift).HasForeignKey(team => team.ShiftId);
        }
    }
}
