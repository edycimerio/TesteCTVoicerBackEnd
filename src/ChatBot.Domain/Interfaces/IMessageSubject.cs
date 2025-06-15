using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o padrão Observer (Subject)
    /// Gerencia observadores de mensagens
    /// </summary>
    public interface IMessageSubject
    {
        /// <summary>
        /// Registra um observador para notificações de mensagens
        /// </summary>
        void RegisterObserver(IMessageObserver observer);
        
        /// <summary>
        /// Remove um observador das notificações
        /// </summary>
        void RemoveObserver(IMessageObserver observer);
        
        /// <summary>
        /// Notifica todos os observadores sobre uma nova mensagem
        /// </summary>
        Task NotifyObserversAsync(string conversationId, string message, string sender);
    }
}
