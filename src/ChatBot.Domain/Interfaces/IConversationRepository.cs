using ChatBot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o repositório de conversas
    /// </summary>
    public interface IConversationRepository
    {
        /// <summary>
        /// Adiciona uma nova conversa
        /// </summary>
        Task AddAsync(Conversation conversation);
        
        /// <summary>
        /// Atualiza uma conversa existente
        /// </summary>
        Task UpdateAsync(Conversation conversation);
        
        /// <summary>
        /// Obtém uma conversa pelo seu ID
        /// </summary>
        Task<Conversation> GetByIdAsync(Guid id);
        
        /// <summary>
        /// Obtém todas as conversas ativas
        /// </summary>
        Task<IEnumerable<Conversation>> GetActiveConversationsAsync();
        
        /// <summary>
        /// Obtém o histórico completo de uma conversa, incluindo todas as mensagens
        /// </summary>
        Task<Conversation> GetConversationWithMessagesAsync(Guid id);
    }
}
