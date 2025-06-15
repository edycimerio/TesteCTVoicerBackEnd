using ChatBot.Domain.Entities;
using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o padrão Observer
    /// Observa eventos de mensagens na conversa
    /// </summary>
    public interface IMessageObserver
    {
        /// <summary>
        /// Método chamado quando uma nova mensagem é enviada
        /// </summary>
        /// <param name="message">A mensagem que foi enviada</param>
        Task OnMessageSentAsync(Message message);
    }
}
