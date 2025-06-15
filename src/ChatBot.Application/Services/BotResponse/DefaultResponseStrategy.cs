using ChatBot.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace ChatBot.Application.Services.BotResponse
{
    public class DefaultResponseStrategy : IBotResponseStrategy
    {
        private static readonly string[] DefaultResponses = new[]
        {
            "Entendi. Como posso ajudar você com isso?",
            "Interessante. Gostaria de saber mais sobre o assunto?",
            "Compreendo. Há algo específico que você gostaria de discutir?",
            "Obrigado por compartilhar. Posso ajudar de alguma outra forma?",
            "Estou aqui para ajudar. O que mais você gostaria de saber?"
        };

        public bool CanProcess(string message)
        {
            // Esta é a estratégia padrão, então sempre pode processar
            return true;
        }

        public Task<string> GenerateResponseAsync(string message)
        {
            Random random = new Random();
            return Task.FromResult(DefaultResponses[random.Next(DefaultResponses.Length)]);
        }
    }
}
