using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.Command.Agent.NewTrip
{
    public class NewTripNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public NewTripNavigationCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new NewTripViewModel();
        }
    }
}
