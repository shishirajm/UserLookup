using System.Collections.Generic;
using System.Threading.Tasks;
using UserLookup.Domain.Users;

namespace UserLookup.Domain.Common
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
