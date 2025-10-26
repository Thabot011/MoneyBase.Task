using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyBase.Domain.Entities;

namespace MoneyBase.Persistence.Configuration
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable(nameof(Agent));
            builder.HasKey(agent => agent.Id);
            builder.Property(agent => agent.Id).ValueGeneratedOnAdd();
            builder.Property(agent => agent.AgentType).IsRequired();
            builder.HasMany(agent => agent.Chats)
                .WithOne(agent => agent.Agent)
                .HasForeignKey(agent => agent.AgentId);
            builder.HasOne(agent => agent.Team)
                .WithMany(agent => agent.Agents)
                .HasForeignKey(agent => agent.TeamId);
        }
    }
}
