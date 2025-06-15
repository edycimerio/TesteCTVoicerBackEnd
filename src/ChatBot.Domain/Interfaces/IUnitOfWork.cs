using System;
using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o padrão Unit of Work
    /// Gerencia transações e persistência de múltiplas operações
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositório de conversas
        /// </summary>
        IConversationRepository ConversationRepository { get; }
        
        /// <summary>
        /// Repositório de mensagens
        /// </summary>
        IMessageRepository MessageRepository { get; }
        
        /// <summary>
        /// Salva todas as alterações feitas no contexto
        /// </summary>
        Task<int> SaveChangesAsync();
        
        /// <summary>
        /// Inicia uma nova transação
        /// </summary>
        Task BeginTransactionAsync();
        
        /// <summary>
        /// Confirma a transação atual
        /// </summary>
        Task CommitTransactionAsync();
        
        /// <summary>
        /// Cancela a transação atual
        /// </summary>
        Task RollbackTransactionAsync();
    }
}
