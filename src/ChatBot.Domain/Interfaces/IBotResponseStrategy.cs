using System.Threading.Tasks;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para estratégias de resposta do bot
    /// Implementa o padrão Strategy para diferentes tipos de respostas
    /// </summary>
    public interface IBotResponseStrategy
    {
        /// <summary>
        /// Verifica se esta estratégia pode processar a mensagem do usuário
        /// </summary>
        /// <param name="userMessage">Mensagem enviada pelo usuário</param>
        bool CanProcess(string userMessage);
        
        /// <summary>
        /// Gera uma resposta para a mensagem do usuário
        /// </summary>
        /// <param name="userMessage">Mensagem enviada pelo usuário</param>
        Task<string> GenerateResponseAsync(string userMessage);
    }
}
