using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UserLookup.Domain.Common;
using UserLookup.Domain.Dto;

namespace UserLookup.Domain.Users
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

        public async Task<List<string>> GetUserNamesByAge(int age)
        {
            var userNames = new List<string>();
            var users = await _userRepository.GetUsers();
            var usersFiltered = users.Where(x => x.Age == age);

            foreach (var user in usersFiltered)
            {
                userNames.Add($"{user.FirstName} {user.LastName}");
            }

            return userNames;
        }

        public Task<List<AgeGenderDto>> GetGenderCountByAge()
        {
            throw new NotImplementedException();
        }
    }
}
