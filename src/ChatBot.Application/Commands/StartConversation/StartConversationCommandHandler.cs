using ChatBot.Domain.Entities;
using ChatBot.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Application.Commands.StartConversation
{
    public class StartConversationCommandHandler : IRequestHandler<StartConversationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StartConversationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(StartConversationCommand request, CancellationToken cancellationToken)
        {
            // Criar uma nova conversa usando o factory method
            var conversation = Conversation.StartNew();

            // Persistir no banco de dados
            await _unitOfWork.ConversationRepository.AddAsync(conversation);
            await _unitOfWork.SaveChangesAsync();

            return conversation.Id;
        }
    }
}
