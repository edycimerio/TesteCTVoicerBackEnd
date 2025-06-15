using ChatBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatBot.Infrastructure.Persistence.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            
            builder.Property(m => m.Id)
                .ValueGeneratedNever();
                
            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(4000);
                
            builder.Property(m => m.Sender)
                .IsRequired()
                .HasConversion<string>();
                
            builder.Property(m => m.SentAt)
                .IsRequired();
                
            // Relacionamento com conversa (many-to-one)
            builder.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .IsRequired();
                
            // Índices para consultas comuns
            builder.HasIndex(m => m.ConversationId);
            builder.HasIndex(m => m.SentAt);
        }
    }
}
