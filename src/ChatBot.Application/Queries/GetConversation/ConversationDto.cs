using ChatBot.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ChatBot.Application.Queries.GetConversation
{
    public class ConversationDto
    {
        public Guid Id { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public string Status { get; set; }
        public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
    }

    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime SentAt { get; set; }
    }
}
