using ChatBot.Domain.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.Application.Services.BotResponse
{
    public class QuestionResponseStrategy : IBotResponseStrategy
    {
        private static readonly Regex QuestionPattern = new Regex(@"\?|o que|como|quando|onde|por que|qual|quem|quanto", RegexOptions.IgnoreCase);

        public bool CanProcess(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return false;

            return QuestionPattern.IsMatch(message);
        }

        public Task<string> GenerateResponseAsync(string message)
        {
            string normalizedMessage = message.Trim().ToLower();
            
            // Respostas específicas para perguntas comuns
            if (normalizedMessage.Contains("seu nome") || normalizedMessage.Contains("quem é você"))
            {
                return Task.FromResult("Eu sou o ChatBot, um assistente virtual desenvolvido para ajudar você.");
            }
            
            if (normalizedMessage.Contains("horas") || normalizedMessage.Contains("que horas"))
            {
                return Task.FromResult($"Agora são {DateTime.Now:HH:mm}.");
            }
            
            if (normalizedMessage.Contains("data") || normalizedMessage.Contains("dia"))
            {
                return Task.FromResult($"Hoje é {DateTime.Now:dd/MM/yyyy}.");
            }
            
            // Respostas genéricas para outras perguntas
            string[] responses = new[]
            {
                "Essa é uma ótima pergunta. Infelizmente, ainda estou aprendendo e não tenho todas as respostas.",
                "Não tenho certeza, mas posso tentar ajudar de outra forma.",
                "Hmm, essa é uma pergunta interessante. Vou precisar aprender mais sobre isso.",
                "Desculpe, não tenho informações suficientes para responder a essa pergunta específica."
            };
            
            Random random = new Random();
            return Task.FromResult(responses[random.Next(responses.Length)]);
        }
    }
}
