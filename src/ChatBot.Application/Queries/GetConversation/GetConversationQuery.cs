using MediatR;
using System;

namespace ChatBot.Application.Queries.GetConversation
{
    public class GetConversationQuery : IRequest<ConversationDto>
    {
        public Guid ConversationId { get; set; }
    }
}
