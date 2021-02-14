using System;
using UserLookup.Domain.Users;
using UserLookup.Infrastructure;

namespace UserLookup.Console
{
    public interface IUiHandler
    {
        int GetUserAction();
        long GetUserId();
        int GetAgeToQuery();
        void DisplayOnUi(string display);
    }

    public class UiHandler : IUiHandler
    {
        public int GetUserAction()
        {
            DisplayOnUi("###########################");
            DisplayOnUi("Enter Action to perfrom");
            DisplayOnUi("0 to Exit.");
            DisplayOnUi("1 to Get User by Id.");
            DisplayOnUi("2 to get User names by Age.");
            DisplayOnUi("3 to get User count by Age and Gender.");
            DisplayOnUi("Enter the digit");
            var inputAction = ReadUserInput();
            int selectedAction;
            if (int.TryParse(inputAction, out selectedAction))
            {
                if (selectedAction >= 0 && selectedAction <= 3)
                    return selectedAction;
                else
                    DisplayOnUi("Invalid input try again!");
            }

            return -1;
        }

        public long GetUserId()
        {
            DisplayOnUi("Enter the User Id to fetch: ");
            var inputId = ReadUserInput();
            long selectedId;
            if (long.TryParse(inputId, out selectedId))
            {
                return selectedId;
            }

            throw new Exception("Id should be a valid number.");
        }

        public int GetAgeToQuery()
        {
            DisplayOnUi("Enter the User Age to fetch names: ");
            var inputAge = ReadUserInput();
            int selectedAge;
            if (int.TryParse(inputAge, out selectedAge))
            {
                if (selectedAge >= 1 && selectedAge <= 150)
                    return selectedAge;
                else
                    throw new Exception("Age should be a valid number:");
            }

            throw new Exception("Age should be a valid number.");
        }

        public void DisplayOnUi(string display)
        {
            System.Console.WriteLine(display);
        }

        private string ReadUserInput()
        {
            return System.Console.ReadLine();
        }
    }
}
