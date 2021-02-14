using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using UserLookup.Domain.Common;
using UserLookup.Domain.Users;

namespace UserLookup.Domain.Tests.Users
{
    public class Tests
    {
        private IUserRepository _mockUserRepository;
        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = Substitute.For<IUserRepository>();
            _userModel = new UserModel(_mockUserRepository);
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(100)]
        public async Task GetUserFullNameById_WhenGetsNoUsersFromRepository_ShouldReturnEmptyName(long id)
        {
            IEnumerable<User> emptyUsers = new List<User>();
            _mockUserRepository.GetUsers().Returns(emptyUsers);

            var result = await _userModel.GetUserFullNameById(id);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(-100)]
        [TestCase(100)]
        public async Task GetUserFullNameById_WhenGetsUsersFromRepository_AndNonExistingIdIsPassed_ShouldReturnEmptyName(long id)
        {
            IEnumerable<User> emptyUsers = new List<User> { new User(1, "FN", "LN", 1, 'M')};
            _mockUserRepository.GetUsers().Returns(emptyUsers);

            var result = await _userModel.GetUserFullNameById(id);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(99)]
        [TestCase(100)]
        public async Task GetUserFullNameById_WhenGetsUsersFromRepository_AndExistingIdIsPassed_ShouldReturnCorrespondingName(long id)
        {
            var firstName = "FN";
            var lastName = "LN";
            IEnumerable<User> emptyUsers = new List<User> { new User(id, firstName, lastName, 18, 'M') };
            _mockUserRepository.GetUsers().Returns(emptyUsers);

            var result = await _userModel.GetUserFullNameById(id);

            Assert.AreEqual($"{firstName} {lastName}", result);
        }
    }
}