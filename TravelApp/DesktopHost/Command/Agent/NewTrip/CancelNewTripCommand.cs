using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.Core.Model;
using System.Windows;

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
            MessageBoxResult result = MessageBox.Show("Are you sure you want to leave this page ?", "Leave page", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                if (_trip == null)
                _navigation.CurrentViewModel = new AgentTripsViewModel();
                else _navigation.CurrentViewModel = new ClientTripDetailsViewModel(_trip.Id);
        }
    }
}
