using ChatBot.Domain.Entities;
using ChatBot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Infrastructure.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _dbContext;

        public MessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
        }

        public async Task<IEnumerable<Message>> GetByConversationIdAsync(Guid conversationId)
        {
            return await _dbContext.Messages
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Messages
                .Include(m => m.Conversation)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
