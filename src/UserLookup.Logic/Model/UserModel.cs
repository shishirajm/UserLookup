using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UserLookup.Domain.Common;

namespace UserLookup.Domain.Model
{
    public class UserModel : IUserModel
    {
        private readonly IUserRepository _userRepository;
        public UserModel(IUserRepository userRepository) => _userRepository = userRepository;


        public async Task<string> GetUserFullNameById(long id)
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
