using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o serviço de respostas do bot
    /// Utiliza o padrão Factory para criar estratégias de resposta
    /// </summary>
    public interface IBotResponseService
    {
        /// <summary>
        /// Processa a mensagem do usuário e retorna uma resposta do bot
        /// </summary>
        /// <param name="userMessage">Mensagem enviada pelo usuário</param>
        /// <returns>Resposta gerada pelo bot</returns>
        Task<string> ProcessMessageAsync(string userMessage);
        
        /// <summary>
        /// Verifica se a mensagem do usuário é um comando para encerrar a conversa
        /// </summary>
        /// <param name="userMessage">Mensagem enviada pelo usuário</param>
        bool IsExitCommand(string userMessage);
    }
}
