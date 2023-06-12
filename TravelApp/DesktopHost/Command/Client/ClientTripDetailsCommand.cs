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

        private ClientTripsViewModel _viewModel;

        public ClientTripDetailsCommand(ClientTripsViewModel viewModel) 
        {
            _navigation = NavigationStore.Instance();
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // TODO : get here which trip and pass fruther
            _navigation.CurrentViewModel = new ClientTripDetailsViewModel(_viewModel.SelectedTrip);
        }
    }
}
