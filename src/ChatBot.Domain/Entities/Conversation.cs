using ChatBot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ChatBot.Domain.Entities
{

    public class Conversation
    {
        public Guid Id { get; private set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? EndedAt { get; private set; }
        public ConversationStatus Status { get; private set; }
        

        public virtual ICollection<Message> Messages { get; private set; } = new List<Message>();


        protected Conversation() 
        {
            Messages = new List<Message>();
        }


        public Conversation(Guid id)
        {
            Id = id;
            StartedAt = DateTime.UtcNow;
            Status = ConversationStatus.Active;
            Messages = new List<Message>();
        }


        public static Conversation StartNew()
        {
            return new Conversation(Guid.NewGuid());
        }


        public void End()
        {
            if (Status == ConversationStatus.Active)
            {
                Status = ConversationStatus.Finished;
                EndedAt = DateTime.UtcNow;
            }
        }


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
