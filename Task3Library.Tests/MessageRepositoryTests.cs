using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Library.Data.Models;
using Task3Library.Repositories;

namespace Task3Library.Tests
{
    public class MessageRepositoryTests : TestsBase
    {

        private readonly MessageRepository _repository;
        private readonly UserRepository _userRepository;

        public MessageRepositoryTests()
        {
            _repository = new MessageRepository(_context);
            _userRepository = new UserRepository(_context);
        }

        public async Task GetUserMessagesTestSuccess()
        {
            var user = new UserDataModel() { Name = "Test", Password="Test123", State="Online"};
            var id = await _userRepository.AddUser(user);

            var user1 = new UserDataModel() { Name = "Test1", Password = "Test123", State = "Online" };
            var id1 = await _userRepository.AddUser(user);

            var message = new MessageDataModel() { UserId = id, ContactId = id1, Content = "TestMessage", SendTime = DateTime.Now };

            await _repository.AddMessage(message);
            var msg = await _repository.GetUserMessages(id);

            Assert.NotNull(msg);

            await _userRepository.DeleteUser(id);
            await _userRepository.DeleteUser(id1);
        }
    }
}
