using NUnit.Framework;
using Task3Library.Data.Models;
using Task3Library.Repositories;
using Assert = Xunit.Assert;

namespace Task3Library.Tests
{
    [TestFixture]
    public class UserRepositoryTests : TestsBase
    {
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            _repository = new UserRepository(_context);
        }

        [Test]
        public async Task AddUserTestSuccess()
        {
            var user = new UserDataModel() { Name = "Test", Password = "Test123", State = "Online" };
            var id = await _repository.AddUser(user);
            user = await _repository.GetUserById(id);
            Assert.NotNull(user);

            await _repository.DeleteUser(id);
        }

        [Test]
        public async Task GetUserByNameTestSuccess()
        {

            var user = new UserDataModel() { Name = "Test", Password = "Test123", State = "Online" };
            await _repository.AddUser(user);
            user = await _repository.GetUserByName("Test");
            Assert.NotNull(user);

            await _repository.DeleteUser(user.Id);
        }

        [Test]
        public async Task SearchUserByNameTestSuccess()
        {
            var user1 = new UserDataModel() { Name = "Test1", Password = "Test123", State = "Online" };
            await _repository.AddUser(user1);
            var user2 = new UserDataModel() { Name = "Test2", Password = "Test123", State = "Online" };
            await _repository.AddUser(user2);
            var user3 = new UserDataModel() { Name = "Test3", Password = "Test123", State = "Online" };
            await _repository.AddUser(user3);

            var users = await _repository.SearchUserByName(x => x.Name.Contains("Te"));
            Assert.Equal(users.Length, 3);

            for (int i = 0; i < users.Length; i++)
            {
                await _repository.DeleteUser(users[i].Id);
            }
        }

        [Test]
        public async Task UpdateUserTestSuccess()
        {
            var user = new UserDataModel() { Name = "Test", Password = "Test123", State = "Online" };
            await _repository.AddUser(user);

            user.Name = "Test23";
            await _repository.UpdateUser(user);

            var updatedUser = await _repository.GetUserByName(user.Name);
            Assert.Equal(updatedUser.Name, user.Name);

            await _repository.DeleteUser(updatedUser.Id);
        }
    }
}
