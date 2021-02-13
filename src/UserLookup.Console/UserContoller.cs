using System;
using System.Threading.Tasks;
using UserLookup.Domain.Users;
using UserLookup.Infrastructure;

namespace UserLookup.Console
{
    public class UserContoller
    {
        private readonly IUserModel _userModel;
        private readonly IUiHandler _uiHandler;

        public UserContoller()
        {
            _userModel = new UserModel(new UserRepository());
            _uiHandler = new UiHandler();
        }

        public UserContoller(IUserModel userModel, IUiHandler uiHandler)
        {
            // For constructor injection during unit testing
            _userModel = userModel;
            _uiHandler = uiHandler;
        }

        public async Task HandleUserInteraction()
        {
            try
            {
                bool flag = true;
                while (flag)
                {
                    var action = _uiHandler.GetUserAction();
                    if (action == 0) flag = false;
                    else if (action == 1) await GetUserById();
                    else if (action == 2) await GetUserNamesByAge();
                    else if (action == 3) await GetUserCountByAgeAndGender();
                    else _uiHandler.DisplayOnUi("Invalid input try again!");
                }
            }
            catch
            {
                _uiHandler.DisplayOnUi("Something went wrong!");
            }
        }

        private async Task GetUserCountByAgeAndGender()
        {
            var ageGenderCounts = await _userModel.GetGenderCountByAge();

            foreach (var ageGender in ageGenderCounts)
            {
                _uiHandler.DisplayOnUi($"Age: {ageGender.Age} Female: {ageGender.Female} Male: {ageGender.Male}");
            }
        }

        private async Task GetUserNamesByAge()
        {
            var age = _uiHandler.GetAgeToQuery();
            var names = await _userModel.GetUserNamesByAge(age);
            if (names.Count == 0)
                _uiHandler.DisplayOnUi($"No users for given age: {age}");
            else
                _uiHandler.DisplayOnUi(string.Join(",", names));
        }

        private async Task GetUserById()
        {
            try
            {
                var id = _uiHandler.GetUserId();
                var userName = await _userModel.GetUserFullNameById(id);

                if (userName == string.Empty)
                {
                    _uiHandler.DisplayOnUi($"No User Id found for given id.");
                }
                else
                {
                    _uiHandler.DisplayOnUi($"{userName}");
                }
                
            }
            catch (Exception ex)
            {
                _uiHandler.DisplayOnUi(ex.Message);
            }

        }
    }
}
