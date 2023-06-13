using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.Core.Model;

namespace TravelApp.DesktopHost.Command.Agent.NewTrip
{
    public class CancelNewTripCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;
        private readonly Trip _trip;

        public CancelNewTripCommand(Trip trip = null)
        {
            _navigation = NavigationStore.Instance();
            _trip = trip;
        }
        public override void Execute(object parameter)
        {
            if (_trip == null)
            _navigation.CurrentViewModel = new AgentTripsViewModel();
            else _navigation.CurrentViewModel = new ClientTripDetailsViewModel(_trip.Id);
        }
    }
}
