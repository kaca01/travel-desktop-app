using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Navigation
{
    class ClientSoldTripsCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public ClientSoldTripsCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new  ClientSoldTripsViewModel();
        }
    }
}
