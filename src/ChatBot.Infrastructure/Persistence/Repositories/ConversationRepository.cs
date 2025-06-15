using ChatBot.Domain.Entities;
using ChatBot.Domain.Enums;
using ChatBot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Infrastructure.Persistence.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext _dbContext;

        public ConversationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Conversation conversation)
        {
            await _dbContext.Conversations.AddAsync(conversation);
        }

        public Task UpdateAsync(Conversation conversation)
        {
            _dbContext.Entry(conversation).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<Conversation?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Conversations
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Conversation>> GetActiveConversationsAsync()
        {
            return await _dbContext.Conversations
                .Where(c => c.Status == ConversationStatus.Active)
                .OrderByDescending(c => c.StartedAt)
                .ToListAsync();
        }

        public async Task<Conversation?> GetConversationWithMessagesAsync(Guid id)
        {
            return await _dbContext.Conversations
                .Include(c => c.Messages.OrderBy(m => m.SentAt))
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
