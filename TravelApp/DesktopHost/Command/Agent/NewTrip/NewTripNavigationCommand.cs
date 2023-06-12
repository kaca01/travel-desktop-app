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

        private BaseViewModel _viewModel;

        public NewTripNavigationCommand(BaseViewModel viewModel)
        {
            _navigation = NavigationStore.Instance();
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {   
            if (_navigation.CurrentViewModel.GetType() == typeof(AgentTripsViewModel))
            {
                _navigation.CurrentViewModel = new NewTripViewModel();

            }
            else if (_navigation.CurrentViewModel.GetType() == typeof(ClientTripDetailsViewModel))
            {
                ClientTripDetailsViewModel viewModel = (ClientTripDetailsViewModel)_viewModel;
                _navigation.CurrentViewModel = new NewTripViewModel(viewModel.Trip);
            }
        }
    }
}
