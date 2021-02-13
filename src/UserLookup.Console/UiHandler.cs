using System;
using UserLookup.Domain.Model;
using UserLookup.Infrastructure;

namespace UserLookup.Console
{
    public interface IUiHandler
    {
        int GetUserAction();
        long GetUserId();
    }

    public class UiHandler : IUiHandler
    {
        public int GetUserAction()
        {
            
            System.Console.WriteLine("Enter Action to perfrom");
            System.Console.WriteLine("0 to Exit.");
            System.Console.WriteLine("1 to Get User by Id.");
            System.Console.WriteLine("2 to get User names by Age.");
            System.Console.WriteLine("3 to get User count by Age and Gender.");
            System.Console.WriteLine("Enter the digit");
            var inputAction = System.Console.ReadLine();
            int selectedAction;
            if (int.TryParse(inputAction, out selectedAction))
            {
                if (selectedAction >= 0 && selectedAction <= 3)
                    return selectedAction;
                else
                    System.Console.WriteLine("Invalid input try again!");
            }

            return -1;
        }

        public long GetUserId()
        {
            System.Console.WriteLine("Enter the User Id to fetch: ");
            var inputId = System.Console.ReadLine();
            long selectedId;
            if (long.TryParse(inputId, out selectedId))
            {
                return selectedId;
            }

            throw new Exception("Id should be a valid number:");
        }

        public void displayonUi(string display)
        {
            System.Console.WriteLine(display);
        }
    }
}
