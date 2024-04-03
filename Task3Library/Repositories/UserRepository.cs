using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Task3Library.Data;
using Task3Library.Data.Models;

namespace Task3Library.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserDataModel> GetUserById(long userId)
        {
            return await _context.UserData.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<UserDataModel> GetUserByName(string userName)
        {
            return await _context.UserData.FirstOrDefaultAsync(x => x.Name == userName);
        }

        public async Task<UserDataModel[]> SearchUserByName(Expression<Func<UserDataModel, bool>> query)
        {
            return await _context.UserData.Where(query).ToArrayAsync();
        }

        public async Task<long> AddUser(UserDataModel user)
        {
            _context.UserData.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateUser(UserDataModel user)
        {
            _context.Attach(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserState(long userId, string userState)
        {
            var user = new UserDataModel() { Id = userId };
            _context.Attach(user);
            user.State = userState;
            _context.Entry(user).Property(x => x.State).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(long userId)
        {
            var user = new UserDataModel() { Id = userId };
            _context.Attach(user);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

    
        

    }
}
