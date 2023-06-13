using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Agent.EditPlace
{
    public class EditPlaceCommand : BaseCommand
    {
        private TouristFacilityService _service;
        private readonly NavigationStore _navigationStore;
        private readonly EditPlaceViewModel _placeVM;
        public EditPlaceCommand(EditPlaceViewModel placeViewModel) 
        {
            _service = new TouristFacilityService();
            _placeVM = placeViewModel;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                var selectedItem = parameter as TouristFacilityListItemViewModel;
                if (_placeVM.EditPlace != null)
                {
                    SetType();
                    _service.Edit(_placeVM.EditPlace);
                    MessageBox.Show("Updated place with name " + _placeVM.Name, "Successfully updated", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationStore.CurrentViewModel = new AgentStayEatViewModel();
                }
                _navigationStore.CurrentViewModel = new AgentStayEatViewModel();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SetType()
        {
            if (_placeVM.Restaurant)
                _placeVM.EditPlace.Type = "RESTAURANT";
            else _placeVM.EditPlace.Type = "ACCOMODATION";
        }
    }
}
