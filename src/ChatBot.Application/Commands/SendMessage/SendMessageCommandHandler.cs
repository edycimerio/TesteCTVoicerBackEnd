using ChatBot.Domain.Enums;
using ChatBot.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBot.Application.Commands.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBotResponseService _botResponseService;

        public SendMessageCommandHandler(
            IUnitOfWork unitOfWork,
            IBotResponseService botResponseService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _botResponseService = botResponseService ?? throw new ArgumentNullException(nameof(botResponseService));
        }

        public async Task<string> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetByIdAsync(request.ConversationId);
            if (conversation == null)
            {
                throw new ArgumentException($"Conversa com ID {request.ConversationId} não encontrada.");
            }

            if (conversation.Status != ConversationStatus.Active)
            {
                throw new InvalidOperationException("Não é possível enviar mensagens para uma conversa finalizada.");
            }

            var userMessage = conversation.AddMessage(request.Message, MessageSender.User);
            
            if (_botResponseService.IsExitCommand(request.Message))
            {
                conversation.End();
                await _unitOfWork.ConversationRepository.UpdateAsync(conversation);
                await _unitOfWork.SaveChangesAsync();
                return "Conversa encerrada.";
            }

            string botResponse = await _botResponseService.ProcessMessageAsync(request.Message);
            
            conversation.AddMessage(botResponse, MessageSender.Bot);
            
            await _unitOfWork.ConversationRepository.UpdateAsync(conversation);
            await _unitOfWork.SaveChangesAsync();

            return botResponse;
        }
    }
}
