using System.Collections.Generic;
using System.Threading.Tasks;
using UserLookup.Domain.Common;

namespace UserLookup.Infrastructure
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository() { }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> asd =  new List<User> { new User(1, "Scott", "Allan", 30, 'M') };
            return asd;

            //using (IDataProvider provider = DataProviderFactory.GetProvider("HTTP"))
            //{
            //    return await provider.QueryData<IEnumerable<User>>();
            //}                
        }
    }
}
