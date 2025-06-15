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
            // Buscar a conversa
            var conversation = await _unitOfWork.ConversationRepository.GetByIdAsync(request.ConversationId);
            if (conversation == null)
            {
                throw new ArgumentException($"Conversa com ID {request.ConversationId} não encontrada.");
            }

            // Verificar se a conversa está ativa
            if (conversation.Status != ConversationStatus.Active)
            {
                throw new InvalidOperationException("Não é possível enviar mensagens para uma conversa finalizada.");
            }

            // Adicionar mensagem do usuário
            var userMessage = conversation.AddMessage(request.Message, MessageSender.User);
            
            // Verificar se é um comando para encerrar a conversa
            if (_botResponseService.IsExitCommand(request.Message))
            {
                conversation.End();
                await _unitOfWork.ConversationRepository.UpdateAsync(conversation);
                await _unitOfWork.SaveChangesAsync();
                return "Conversa encerrada.";
            }

            // Processar a mensagem e obter resposta do bot
            string botResponse = await _botResponseService.ProcessMessageAsync(request.Message);
            
            // Adicionar resposta do bot
            conversation.AddMessage(botResponse, MessageSender.Bot);
            
            // Salvar as alterações
            await _unitOfWork.ConversationRepository.UpdateAsync(conversation);
            await _unitOfWork.SaveChangesAsync();

            return botResponse;
        }
    }
}
