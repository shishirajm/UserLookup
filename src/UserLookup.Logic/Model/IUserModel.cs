using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserLookup.Domain.Model
{
    public interface IUserModel
    {
        Task<string> GetUserFullNameById(long id);
        Task<List<string>> GetUsersByAge(int age);
        Task<string> GetGendersByAge();
    }
}
