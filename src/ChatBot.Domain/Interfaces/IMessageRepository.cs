using ChatBot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de mensagens
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Adiciona uma nova mensagem
        /// </summary>
        Task AddAsync(Message message);
        
        /// <summary>
        /// Obtém todas as mensagens de uma conversa
        /// </summary>
        Task<IEnumerable<Message>> GetByConversationIdAsync(Guid conversationId);
        
        /// <summary>
        /// Obtém uma mensagem pelo seu ID
        /// </summary>
        Task<Message?> GetByIdAsync(Guid id);
    }
}
