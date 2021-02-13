using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UserLookup.Repository.Entities;
using UserLookup.Repository;

namespace UserLookup.Logic
{
    public interface IUserLookup
    {
        Task<string> GetUserById(long id);
        Task<List<string>> GetUsersByAge(int age);
        Task<string> GetGendersByAge();
    }

    public class UserLookup : IUserLookup
    {
        private readonly UserRepository _userRepository;
        public UserLookup(UserRepository userRepository) => _userRepository = userRepository;


        public async Task<string> GetUserById(long id)
        {
            var fullName = "";
            var users = await _userRepository.GetUsers();
            var usersFiltered = users.Where(x => x.Id == id);

            foreach (var user in usersFiltered)
            {
                fullName = $"{user.FirstName} {user.LastName}";
                break;
            }

            return fullName;
        }

        public Task<string> GetGendersByAge()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUsersByAge(int age)
        {
            throw new NotImplementedException();
        }
    }
}
