using ChatBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatBot.Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .ValueGeneratedNever();
                
            builder.Property(c => c.StartedAt)
                .IsRequired();
                
            builder.Property(c => c.Status)
                .IsRequired();
                
            builder.HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasIndex(c => c.Status);
        }
    }
}
