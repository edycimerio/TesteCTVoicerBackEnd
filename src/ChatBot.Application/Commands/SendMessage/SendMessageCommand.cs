using MediatR;
using System;

namespace ChatBot.Application.Commands.SendMessage
{
    public class SendMessageCommand : IRequest<string>
    {
        public Guid ConversationId { get; set; }
        public string Message { get; set; }
    }
}
