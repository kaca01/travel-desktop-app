using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.Command
{
    class ClientStayEatNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public ClientStayEatNavigationCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new ClientStayEatViewModel();
        }
    }
}
