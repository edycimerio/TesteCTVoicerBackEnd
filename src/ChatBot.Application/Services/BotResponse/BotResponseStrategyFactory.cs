using ChatBot.Domain.Interfaces;
using System.Collections.Generic;

namespace ChatBot.Application.Services.BotResponse
{
    public class BotResponseStrategyFactory : IBotResponseStrategyFactory
    {
        public IEnumerable<IBotResponseStrategy> CreateStrategies()
        {
            // Criar e retornar todas as estratégias de resposta disponíveis
            // A ordem é importante: as estratégias mais específicas devem vir primeiro
            return new List<IBotResponseStrategy>
            {
                new GreetingResponseStrategy(),
                new QuestionResponseStrategy(),
                new DefaultResponseStrategy() // Estratégia padrão deve ser a última
            };
        }
    }
}
