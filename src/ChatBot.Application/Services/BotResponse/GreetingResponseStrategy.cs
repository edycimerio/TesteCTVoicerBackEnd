using ChatBot.Domain.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.Application.Services.BotResponse
{
    public class GreetingResponseStrategy : IBotResponseStrategy
    {
        private static readonly string[] GreetingPatterns = new[]
        {
            "olá",
            "oi",
            "bom dia",
            "boa tarde",
            "boa noite",
            "e aí",
            "tudo bem",
            "como vai"
        };

        public bool CanProcess(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return false;

            string normalizedMessage = message.Trim().ToLower();
            
            foreach (var pattern in GreetingPatterns)
            {
                if (normalizedMessage.Contains(pattern))
                {
                    return true;
                }
            }
            
            return false;
        }

        public Task<string> GenerateResponseAsync(string message)
        {
            string timeBasedGreeting = GetTimeBasedGreeting();
            string[] responses = new[]
            {
                $"{timeBasedGreeting}! Como posso ajudar você hoje?",
                $"{timeBasedGreeting}! Em que posso ser útil?",
                $"Olá! Estou aqui para ajudar. O que você precisa?"
            };
            
            Random random = new Random();
            return Task.FromResult(responses[random.Next(responses.Length)]);
        }
        
        private string GetTimeBasedGreeting()
        {
            var hour = DateTime.Now.Hour;
            
            if (hour >= 5 && hour < 12)
                return "Bom dia";
            else if (hour >= 12 && hour < 18)
                return "Boa tarde";
            else
                return "Boa noite";
        }
    }
}
