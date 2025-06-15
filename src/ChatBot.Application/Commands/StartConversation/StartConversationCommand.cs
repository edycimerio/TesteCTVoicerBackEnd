using MediatR;
using System;

namespace ChatBot.Application.Commands.StartConversation
{
    public class StartConversationCommand : IRequest<Guid>
    {
        // Comando simples sem parâmetros, pois apenas iniciamos uma nova conversa
    }
}
