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


            builder.HasData(
                new Shift
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    StartTime = new TimeOnly(8, 0),
                    EndTime = new TimeOnly(16, 0),
                    ShiftType = ShiftType.Morning
                },
                new Shift
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    StartTime = new TimeOnly(16, 0),
                    EndTime = new TimeOnly(0, 0),
                    ShiftType = ShiftType.Afternoon
                },
                new Shift
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    StartTime = new TimeOnly(0, 0),
                    EndTime = new TimeOnly(8, 0),
                    ShiftType = ShiftType.Night
                },
                new Shift
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    StartTime = new TimeOnly(0, 0),
                    EndTime = new TimeOnly(0, 0),
                    ShiftType = ShiftType.Overflow
                }
            );
        }
    }
}
