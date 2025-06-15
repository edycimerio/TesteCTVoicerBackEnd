using ChatBot.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Application.Services.BotResponse
{
    public class BotResponseService : IBotResponseService
    {
        private readonly IEnumerable<IBotResponseStrategy> _strategies;

        public BotResponseService(IBotResponseStrategyFactory strategyFactory)
        {
            if (strategyFactory == null)
                throw new ArgumentNullException(nameof(strategyFactory));
            
            _strategies = strategyFactory.CreateStrategies();
        }

        public async Task<string> ProcessMessageAsync(string userMessage)
        {
            var strategy = _strategies.FirstOrDefault(s => s.CanProcess(userMessage));
            
            if (strategy == null)
            {
                strategy = _strategies.Last();
            }
            
            return await strategy.GenerateResponseAsync(userMessage);
        }

        public bool IsExitCommand(string userMessage)
        {
            string normalizedMessage = userMessage.Trim().ToLower();
            return normalizedMessage == "sair" || 
                   normalizedMessage == "encerrar" || 
                   normalizedMessage == "tchau" ||
                   normalizedMessage == "adeus";
        }
    }
}
