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

        public async Task<List<AgeGenderDto>> GetGenderCountByAge()
        {
            // Disctionary used here with performance in focus
            // using lists with adding more objects would reduce performance
            var userStore = new Dictionary<int, AgeGenderDto>();
            var users = await _userRepository.GetUsers();

            foreach (var user in users)
            {
                if (userStore.ContainsKey(user.Age))
                {
                    var existing = userStore[user.Age];
                    GetIncrementedGenderCount(existing, user);
                    userStore[user.Age] = existing;
                } else
                {
                    var dto = new AgeGenderDto { Age = user.Age, Male = 0, Female = 0};
                    dto = GetIncrementedGenderCount(dto, user);
                    userStore.Add(user.Age, dto);
                }
            }

            var values = new List<AgeGenderDto>(userStore.Values);
            values.Sort((a, b) => a.Age.CompareTo(b.Age));

            return values;
        }

        private AgeGenderDto GetIncrementedGenderCount(AgeGenderDto dto, User user)
        {
            if (user.Gender == 'M')
                dto.Male += 1;
            else if (user.Gender == 'F')
                dto.Female += 1;

            return dto;
        }
    }
}
