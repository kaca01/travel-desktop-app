using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Navigation
{
    class LogOutCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public LogOutCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            UserService.CurrentUser = null;
            _navigation.CurrentViewModel = new LoginViewModel();
        }
    }
}
