using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.Core.Model;
using System.Windows;

namespace TravelApp.DesktopHost.Command.Agent
{
    public class CreateNewPlaceCommand : BaseCommand
    {
        private TouristFacilityService _service;
        private readonly NavigationStore _navigationStore;
        private readonly NewPlaceViewModel _placeVM;

        public CreateNewPlaceCommand(NewPlaceViewModel placeVM)
        {
            _service = new TouristFacilityService();
            _placeVM = placeVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                TouristFacility tf =  _service.Create(_placeVM);
                MessageBox.Show("Created place with name "+ _placeVM.Name, "Successfully created", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = new AgentStayEatViewModel();
            }
            catch (Exception e)
            {
                _placeVM.SnackbarMessageQueue.Enqueue(e.Message);
            }
        }
    }
}
