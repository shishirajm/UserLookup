using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserLookup.Domain.Common;
using UserLookup.Domain.Users;
using UserLookup.Infrastructure.DataProvider;
using Microsoft.Extensions.Caching.Memory;

namespace UserLookup.Infrastructure.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly IMemoryCache _cache;
        const string CacheKey = "UserPayload";

        public UserRepository()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public UserRepository(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var (fetched, users) = GetUsersFromCache();

            if (fetched)
            {
                return users;
            }

            using (IDataProvider provider = DataProviderFactory.GetProvider("HTTP"))
            {
                var apiUsers = await provider.QueryData<List<ApiUser>>();
                users = MapApiUserToDomainUser(apiUsers);
            }

            CacheUsers(users);
            return users;
        }

        private (bool, IEnumerable<User>) GetUsersFromCache()
        {
            if (_cache.TryGetValue(CacheKey, out IEnumerable<User> users))
            {
                return (true, users);
            }

            return (false, users);
        }

        // For now implemented the in memory caching and for 5 minutes, but based on requirements this can be modified
        private void CacheUsers(IEnumerable<User> users)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(CacheKey, users, cacheEntryOptions);
        }

        // Models of User and ApiUuser are kept separate as Domain user can have multiple data source
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
            public long Id { get; set; }

            public string First { get; set; }

            public string Last { get; set; }

            public int Age { get; set; }

            public string Gender { get; set; }
        }
    }
}
