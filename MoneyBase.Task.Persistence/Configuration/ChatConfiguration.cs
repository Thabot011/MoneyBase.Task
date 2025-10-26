using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyBase.Domain.Entities;

namespace MoneyBase.Persistence.Configuration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable(nameof(Chat));
            builder.HasKey(chat => chat.Id);
            builder.Property(chat => chat.Id).ValueGeneratedOnAdd();
            builder.Property(chat => chat.Title).HasMaxLength(60).IsRequired();
            builder.Property(chat => chat.ChatStatus);
            builder.Property(chat => chat.LastPollAt);
            builder.HasOne(chat => chat.Agent)
                .WithMany(chat => chat.Chats)
                .HasForeignKey(account => account.AgentId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
