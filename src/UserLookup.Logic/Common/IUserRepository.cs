using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserLookup.Domain.Common
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
