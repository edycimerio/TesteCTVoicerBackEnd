namespace ChatBot.Domain.Enums
{
    /// <summary>
    /// Indica quem enviou a mensagem
    /// </summary>
    public enum MessageSender
    {
        /// <summary>
        /// Mensagem enviada pelo usuário
        /// </summary>
        User = 1,
        
        /// <summary>
        /// Mensagem enviada pelo bot
        /// </summary>
        Bot = 2
    }
}
