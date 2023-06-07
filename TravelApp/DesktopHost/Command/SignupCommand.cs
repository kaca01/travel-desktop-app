using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using System.Windows;

namespace TravelApp.DesktopHost.Command
{
    public class SignupCommand : BaseCommand
    {
        private UserService _userService;
        private readonly NavigationStore _navigationStore;
        private readonly SignupViewModel _signupVM;

        public SignupCommand(SignupViewModel signupVM)
        {
            _userService = new UserService();
            _signupVM = signupVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                Validation user = new Validation(_signupVM.Name, _signupVM.Surname, _signupVM.Email, _signupVM.Password, _signupVM.PasswordAgain);  
                _userService.Signup(user, _signupVM);
                _navigationStore.CurrentViewModel = new LoginViewModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
