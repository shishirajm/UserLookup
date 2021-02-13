using System.Collections.Generic;
using System.Threading.Tasks;
using UserLookup.Domain.Common;
using UserLookup.Domain.Users;
using UserLookup.Infrastructure.DataProvider;

namespace UserLookup.Infrastructure
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository() { }

        public async Task<IEnumerable<User>> GetUsers()
        {
            //IEnumerable<User> mock =  new List<User> {
            //    new User(1, "Scott", "Allan", 30, 'M'),
            //    new User(2, "Peat", "Allan", 30, 'M'),
            //    new User(3, "Kate", "Allan", 30, 'F'),
            //    new User(4, "Sweet", "Allan", 20, 'M')
            //};
            //return mock;

            IEnumerable<User> users;
            using (IDataProvider provider = DataProviderFactory.GetProvider("HTTP"))
            {
                var apiUsers = await provider.QueryData<List<ApiUser>>();
                users = MapApiUserToDomainUser(apiUsers);
            }

            return users;
        }

        // Domain user and API user are kept separate as Domain user can have multiple data source
        private User[] MapApiUserToDomainUser(List<ApiUser> apiUsers)
        {
            User[] tempUsers = new User[apiUsers.Count];
            var index = 0;
            foreach (var apiUser in apiUsers)
            {
                tempUsers[index] = new User(apiUser.Id, apiUser.First, apiUser.Last, apiUser.Age, apiUser.Gender[0]);
                index++;
            }

            return tempUsers;
        }

        private class ApiUser
        {
            public long Id { get; protected set; }

            public string First { get; set; }

            public string Last { get; set; }

            public int Age { get; set; }

            public string Gender { get; set; }
        }
    }
}
