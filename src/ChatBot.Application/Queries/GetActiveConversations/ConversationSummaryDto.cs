using System;

namespace ChatBot.Application.Queries.GetActiveConversations
{
    public class ConversationSummaryDto
    {
        public Guid Id { get; set; }
        public DateTime StartedAt { get; set; }
        public int MessageCount { get; set; }
    }
}
