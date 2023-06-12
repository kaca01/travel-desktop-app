using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.Command.Agent.NewTrip
{
    public class CreateNewTripCommand : BaseCommand
    {
        private TripService _service;
        private readonly NavigationStore _navigationStore;
        private readonly NewTripViewModel _placeVM;

        public CreateNewTripCommand(NewTripViewModel placeVM)
        {
            _service = new TripService();
            _placeVM = placeVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                Trip tf = _service.Create(_placeVM);
                MessageBox.Show("Created trip with name " + _placeVM.Name, "Successfully created", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new AgentTripsViewModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
