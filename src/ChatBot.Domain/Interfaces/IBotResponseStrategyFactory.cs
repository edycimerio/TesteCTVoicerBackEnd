using System.Collections.Generic;

namespace ChatBot.Domain.Interfaces
{
    /// <summary>
    /// Interface para o padrão Factory
    /// Cria estratégias de resposta do bot
    /// </summary>
    public interface IBotResponseStrategyFactory
    {
        /// <summary>
        /// Cria todas as estratégias de resposta disponíveis
        /// </summary>
        /// <returns>Lista de estratégias de resposta</returns>
        IEnumerable<IBotResponseStrategy> CreateStrategies();
    }
}
