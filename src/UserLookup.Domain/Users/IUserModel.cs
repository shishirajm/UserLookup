using System.Collections.Generic;
using System.Threading.Tasks;
using UserLookup.Domain.Dto;

namespace UserLookup.Domain.Users
{
    public interface IUserModel
    {
        Task<string> GetUserFullNameById(long id);
        Task<List<string>> GetUserNamesByAge(int age);
        Task<List<AgeGenderDto>> GetGenderCountByAge();
    }
}
