using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task3Library.Data;
using Task3Library.Data.Models;

namespace Task3Library.Repositories
{
    public class ContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ContactDataModel> GetUserContact(long userID, long contactId)
        {
            return await _context.ContactData.FirstOrDefaultAsync(x => (x.UserId == userID && x.ContactId == contactId));
        }

        public async Task<ContactDataModel[]> GetUserContacts(long userId)
        {
            return await _context.ContactData.Where(x => x.UserId == userId).ToArrayAsync();
        }

        public async Task<ContactDataModel> SearchUserContact(long userId, Expression<Func<ContactDataModel, bool>> query)
        {
            return await _context.ContactData.Where(x => x.UserId == userId).FirstOrDefaultAsync(query);
        }

        public async Task AddContact(ContactDataModel contact)
        {
            _context.ContactData.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpadateContact(ContactDataModel contact)
        {
            _context.Attach(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(long userId, long contactId)
        {
            var contact = new ContactDataModel() { UserId = userId, ContactId = contactId };
            _context.Attach(contact);
            _context.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
