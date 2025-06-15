namespace ChatBot.Domain.Enums
{
    /// <summary>
    /// Status da conversa entre usuário e bot
    /// </summary>
    public enum ConversationStatus
    {
        /// <summary>
        /// Conversa ativa/em andamento
        /// </summary>
        Active = 1,
        
        /// <summary>
        /// Conversa finalizada pelo usuário
        /// </summary>
        Finished = 2
    }
}
