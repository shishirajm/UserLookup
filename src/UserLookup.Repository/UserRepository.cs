using System.Collections.Generic;
using UserLookup.Repository.Entities;
using UserLookup.Repository.DataProvider;
using System.Threading.Tasks;

namespace UserLookup.Repository
{
    public class UserRepository: Repository<User>
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
