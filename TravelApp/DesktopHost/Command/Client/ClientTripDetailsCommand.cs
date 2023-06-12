using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command
{
    public class ClientTripDetailsCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        private BaseViewModel _viewModel;

        public ClientTripDetailsCommand(BaseViewModel viewModel) 
        {
            _navigation = NavigationStore.Instance();
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_navigation.CurrentViewModel.GetType() == typeof(ClientTripsViewModel))
            {
                ClientTripsViewModel viewModel = (ClientTripsViewModel)_viewModel;
                _navigation.CurrentViewModel = new ClientTripDetailsViewModel(viewModel.SelectedTrip);

            }
            else
            {
                AgentTripsViewModel viewModel = (AgentTripsViewModel)_viewModel;
                _navigation.CurrentViewModel = new ClientTripDetailsViewModel(viewModel.SelectedTrip);

            }
        }
    }
}
