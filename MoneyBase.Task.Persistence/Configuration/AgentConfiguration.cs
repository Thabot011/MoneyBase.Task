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


            builder.HasData(
                new Agent
                {
                    Id = Guid.Parse("fb8ae7f6-d7e0-4b4f-9dcf-1724359ef47e"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    MaxChats = 4
                },
                new Agent
                {
                    Id = Guid.Parse("8611e452-7928-4ca6-8ba8-6c4bfffc74f5"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("d8f367c4-7c5d-4978-9132-28af793186d1"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    MaxChats = 4
                },
                new Agent
                {
                    Id = Guid.Parse("63fcef60-59c8-4d7c-bf65-6b66d3d414f3"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("6eda5f9c-9284-4702-b6e5-684bbc797032"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("7d7094b1-2fc1-4943-b473-28e9b88aa806"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("2d99f557-8671-4eff-b461-c50871e16cc5"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("b9595f82-3cf4-46d3-b7e8-e27946f3f396"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                }, new Agent
                {
                    Id = Guid.Parse("68c4ca08-3825-444b-bc73-e95d0ae574c1"),
                    AgentType = AgentType.Junior,
                    TeamId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    MaxChats = 4
                },
                new Agent
                {
                    Id = Guid.Parse("835c96b0-6056-473c-ad26-93ccb557e480"),
                    AgentType = AgentType.MidLevel,
                    TeamId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    MaxChats = 6,
                },
                new Agent
                {
                    Id = Guid.Parse("bfd5bf77-839d-412f-a96d-191c05a63b45"),
                    AgentType = AgentType.MidLevel,
                    TeamId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    MaxChats = 6
                },
                new Agent
                {
                    Id = Guid.Parse("a1dd117d-0c48-49ea-bf9c-109f5ca25705"),
                    AgentType = AgentType.MidLevel,
                    TeamId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    MaxChats = 6,
                },
                new Agent
                {
                    Id = Guid.Parse("1a44ed26-47e4-477b-8a03-bab0d8926311"),
                    AgentType = AgentType.MidLevel,
                    TeamId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    MaxChats = 6
                },
                new Agent
                {
                    Id = Guid.Parse("1ca1a930-a8af-4bff-b70c-d8dcb3375d39"),
                    AgentType = AgentType.Senior,
                    TeamId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    MaxChats = 8
                },
                new Agent
                {
                    Id = Guid.Parse("e5f8a12d-dc8d-48f8-a754-bf5d9eaf38ab"),
                    AgentType = AgentType.TeamLead,
                    TeamId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    MaxChats = 5
                }
            );
        }
    }
}
