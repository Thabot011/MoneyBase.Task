using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyBase.Domain.Entities;

namespace MoneyBase.Persistence.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(nameof(Team));
            builder.HasKey(team => team.Id);
            builder.Property(team => team.Id).ValueGeneratedOnAdd();
            builder.Property(team => team.TeamName).HasMaxLength(60).IsRequired();
            builder.HasMany(team => team.Agents)
                .WithOne(team => team.Team)
                .HasForeignKey(agent => agent.TeamId);
            builder.HasOne(team => team.Shift)
          .WithMany(team => team.Teams).HasForeignKey(team => team.ShiftId);


            builder.HasData(
                new Team
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    TeamName = "Team A",
                    ShiftId = Guid.Parse("11111111-1111-1111-1111-111111111111")
                },
                new Team
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    TeamName = "Team B",
                    ShiftId = Guid.Parse("22222222-2222-2222-2222-222222222222")
                },
                new Team
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    TeamName = "Team C",
                    ShiftId = Guid.Parse("33333333-3333-3333-3333-333333333333")
                },
                new Team
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    TeamName = "Overflow team",
                    ShiftId = Guid.Parse("44444444-4444-4444-4444-444444444444")
                }
            );
        }
    }
}
