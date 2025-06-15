using MediatR;
using System;

namespace ChatBot.Application.Commands.EndConversation
{
    public class EndConversationCommand : IRequest<bool>
    {
        public Guid ConversationId { get; set; }
    }
}
