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
                    else if (action == 2) GetUserNamesByAge();
                    else if (action == 3) GetUserCountByAgeAndGender();
                    else _uiHandler.displayonUi("Invalid input try again!");
                }
            }
            catch
            {

            }
        }

        private void GetUserCountByAgeAndGender()
        {
            throw new NotImplementedException();
        }

        private void GetUserNamesByAge()
        {
            throw new NotImplementedException();
        }

        private async Task GetUserById()
        {
            try
            {
                var id = _uiHandler.GetUserId();
                var userName = await _userModel.GetUserFullNameById(id);

                if (userName == string.Empty)
                {
                    _uiHandler.displayonUi($"No User Id found for given id.");
                }
                else
                {
                    _uiHandler.displayonUi($"User name for Id {id} is {userName}");
                }
                
            }
            catch (Exception ex)
            {
                _uiHandler.displayonUi(ex.Message);
            }

        }
    }
}
