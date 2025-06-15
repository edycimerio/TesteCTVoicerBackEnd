using ChatBot.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Application.Commands.EndConversation
{
    public class EndConversationCommandHandler : IRequestHandler<EndConversationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EndConversationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> Handle(EndConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetByIdAsync(request.ConversationId);
            if (conversation == null)
            {
                throw new ArgumentException($"Conversa com ID {request.ConversationId} não encontrada.");
            }

            conversation.End();
            
            await _unitOfWork.ConversationRepository.UpdateAsync(conversation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
