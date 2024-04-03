using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task3Library.Data;
using Task3Library.Data.Models;

namespace Task3Library.Repositories
{
    public class MessageRepository
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<MessageDataModel[]> GetUserMessages(long userId)
        {
            return await _context.MessageData.Where(x => x.UserId == userId).ToArrayAsync();
        }
        public async Task<MessageDataModel> SearchUserMessages(long userId, long contactId, Expression<Func<MessageDataModel, bool>> query)
        {
            return await _context.MessageData.Where(x => x.UserId == userId && x.ContactId == contactId).FirstOrDefaultAsync(query);
        }
        public async Task AddMessage(MessageDataModel message)
        {
            _context.MessageData.Add(message);
            await _context.SaveChangesAsync();
        }

    }
}
