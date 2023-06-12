using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.Core.Service;
using TravelApp.Core.Model;
using MaterialDesignThemes.Wpf;
using System.Windows;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.Command
{
    public class LoginCommand : BaseCommand
    {
        private UserService _userService;
        private readonly NavigationStore _navigationStore;
        private readonly LoginViewModel _loginVM;

        public LoginCommand(LoginViewModel loginVM)
        {
            _userService = new UserService();
            _loginVM = loginVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                _userService.Login(_loginVM.Email, _loginVM.Password);
                _loginVM.ErrorVisibility = System.Windows.Visibility.Collapsed;
                if (UserService.CurrentUser.Role.Equals(Role.CLIENT))
                {
                    _navigationStore.CurrentViewModel = new ClientTripsViewModel();
                }
                else if (UserService.CurrentUser.Role.Equals(Role.AGENT))
                {
                    _navigationStore.CurrentViewModel = new NewAttractionViewModel();
                }
            }
            catch(Exception e) 
            {
                _loginVM.ErrorVisibility = System.Windows.Visibility.Visible;
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
