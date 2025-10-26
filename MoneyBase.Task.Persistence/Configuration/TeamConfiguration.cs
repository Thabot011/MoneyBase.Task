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
        }
    }
}
