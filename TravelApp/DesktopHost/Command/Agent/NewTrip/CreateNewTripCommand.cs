using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;

namespace TravelApp.DesktopHost.Command.Agent.NewTrip
{
    public class CreateNewTripCommand : BaseCommand
    {
        private TripService _service;
        private readonly NavigationStore _navigationStore;
        private readonly NewTripViewModel _placeVM;
        private readonly Trip _trip;

        public CreateNewTripCommand(NewTripViewModel placeVM, Trip trip = null)
        {
            _service = new TripService();
            _placeVM = placeVM;
            _trip = trip;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (_trip != null)
                {
                    _service.Delete(_trip.Id);
                    Trip tf = _service.Create(_placeVM);
                    MessageBox.Show("Updated trip with name " + _placeVM.Name, "Successfully updated", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationStore.CurrentViewModel = new ClientTripDetailsViewModel(tf.Id);
                }
                else
                {
                    Trip tf = _service.Create(_placeVM);
                    MessageBox.Show("Created trip with name " + _placeVM.Name, "Successfully created", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationStore.CurrentViewModel = new AgentTripsViewModel();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
