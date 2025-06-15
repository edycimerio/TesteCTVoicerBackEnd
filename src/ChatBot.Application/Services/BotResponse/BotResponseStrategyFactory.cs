using ChatBot.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot.Application.Services.BotResponse
{
    public class BotResponseStrategyFactory : IBotResponseStrategyFactory
    {
        private readonly IEnumerable<IBotResponseStrategy> _strategies;

        public BotResponseStrategyFactory(IEnumerable<IBotResponseStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IEnumerable<IBotResponseStrategy> CreateStrategies()
        {
            var specificStrategies = _strategies.Where(s => s.GetType() != typeof(DefaultResponseStrategy)).ToList();
            var defaultStrategy = _strategies.FirstOrDefault(s => s.GetType() == typeof(DefaultResponseStrategy));
            
            if (defaultStrategy != null)
            {
                specificStrategies.Add(defaultStrategy);
            }
            
            return specificStrategies;
        }
    }
}
