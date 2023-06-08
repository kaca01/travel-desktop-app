using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Navigation
{
    class ClientTripsCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public ClientTripsCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            // TODO : add here _navigation.CurrentViewModel = new TripsViewModel()
            // or whatever the class is called
            if(_navigation.CurrentViewModel.GetType() != typeof(ClientTripsViewModel))
                _navigation.CurrentViewModel = new ClientTripsViewModel();
        }
    }
}
