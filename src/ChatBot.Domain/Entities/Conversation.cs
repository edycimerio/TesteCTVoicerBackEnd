using ChatBot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ChatBot.Domain.Entities
{
    /// <summary>
    /// Representa uma conversa entre usuário e bot
    /// </summary>
    public class Conversation
    {
        public Guid Id { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? EndedAt { get; private set; }
        public ConversationStatus Status { get; private set; }
        
        // Propriedade de navegação para mensagens
        public virtual ICollection<Message> Messages { get; private set; }

        // Construtor para EF Core
        protected Conversation() { }

        // Construtor para nova conversa
        public Conversation(Guid id)
        {
            Id = id;
            StartedAt = DateTime.UtcNow;
            Status = ConversationStatus.Active;
            Messages = new List<Message>();
        }

        // Factory Method para criar nova conversa
        public static Conversation StartNew()
        {
            return new Conversation(Guid.NewGuid());
        }

        // Método para finalizar a conversa
        public void End()
        {
            if (Status == ConversationStatus.Active)
            {
                Status = ConversationStatus.Finished;
                EndedAt = DateTime.UtcNow;
            }
        }

        // Método para adicionar uma mensagem à conversa
        public Message AddMessage(string content, MessageSender sender)
        {
            if (Status != ConversationStatus.Active)
            {
                throw new InvalidOperationException("Não é possível adicionar mensagens a uma conversa finalizada.");
            }

            var message = new Message(Guid.NewGuid(), this.Id, content, sender);
            Messages.Add(message);
            return message;
        }
    }
}
