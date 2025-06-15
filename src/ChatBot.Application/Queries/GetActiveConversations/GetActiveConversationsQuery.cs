using MediatR;
using System.Collections.Generic;

namespace ChatBot.Application.Queries.GetActiveConversations
{
    public class GetActiveConversationsQuery : IRequest<List<ConversationSummaryDto>>
    {
        // Consulta simples sem parâmetros
    }
}
