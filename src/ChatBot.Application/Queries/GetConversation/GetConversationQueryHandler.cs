using ChatBot.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Application.Queries.GetConversation
{
    public class GetConversationQueryHandler : IRequestHandler<GetConversationQuery, ConversationDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConversationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ConversationDto> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetConversationWithMessagesAsync(request.ConversationId);
            
            if (conversation == null)
            {
                return null;
            }

            var conversationDto = new ConversationDto
            {
                Id = conversation.Id,
                StartedAt = conversation.StartedAt,
                EndedAt = conversation.EndedAt,
                Status = conversation.Status.ToString(),
                Messages = conversation.Messages.Select(m => new MessageDto
                {
                    Id = m.Id,
                    Content = m.Content,
                    Sender = m.Sender.ToString(),
                    SentAt = m.SentAt
                }).ToList()
            };

            return conversationDto;
        }
    }
}
