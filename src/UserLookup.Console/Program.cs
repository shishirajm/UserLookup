using System.Threading.Tasks;
using UserLookup.Domain.Model;
using UserLookup.Infrastructure;

namespace UserLookup.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var userController = new UserContoller();
            await userController.HandleUserInteraction();
            System.Console.WriteLine($"Exiting the Application. Thank you.");
        }
    }
}
