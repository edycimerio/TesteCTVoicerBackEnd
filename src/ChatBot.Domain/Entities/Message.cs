using ChatBot.Domain.Enums;
using System;

namespace ChatBot.Domain.Entities
{
    /// <summary>
    /// Representa uma mensagem na conversa entre usuário e bot
    /// </summary>
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid ConversationId { get; private set; }
        public string Content { get; private set; }
        public MessageSender Sender { get; private set; }
        public DateTime SentAt { get; private set; }
        
        // Propriedade de navegação para conversa
        public virtual Conversation Conversation { get; private set; }

        // Construtor para EF Core
        protected Message() { }

        // Construtor para nova mensagem
        public Message(Guid id, Guid conversationId, string content, MessageSender sender)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("O conteúdo da mensagem não pode ser vazio.", nameof(content));

            Id = id;
            ConversationId = conversationId;
            Content = content;
            Sender = sender;
            SentAt = DateTime.UtcNow;
        }
    }
}
