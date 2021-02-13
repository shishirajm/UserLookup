using System.Threading.Tasks;
using UserLookup.Repository;

namespace UserLookup
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var userLookup = new Logic.UserLookup(new UserRepository());
            var fullName = await userLookup.GetUserById(1);
            System.Console.WriteLine($"{fullName}");
        }
    }
}
