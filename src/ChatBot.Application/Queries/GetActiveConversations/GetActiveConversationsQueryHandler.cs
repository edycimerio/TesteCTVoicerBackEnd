using ChatBot.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Application.Queries.GetActiveConversations
{
    public class GetActiveConversationsQueryHandler : IRequestHandler<GetActiveConversationsQuery, List<ConversationSummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveConversationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<List<ConversationSummaryDto>> Handle(GetActiveConversationsQuery request, CancellationToken cancellationToken)
        {
            var activeConversations = await _unitOfWork.ConversationRepository.GetActiveConversationsAsync();
            
            var result = new List<ConversationSummaryDto>();
            
            foreach (var conversation in activeConversations)
            {
                var conversationWithMessages = await _unitOfWork.ConversationRepository.GetConversationWithMessagesAsync(conversation.Id);
                
                result.Add(new ConversationSummaryDto
                {
                    Id = conversation.Id,
                    StartedAt = conversation.StartedAt,
                    MessageCount = conversationWithMessages.Messages.Count
                });
            }
            
            return result;
        }
    }
}
