using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Repository;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command
{
    class DeleteStayEatItemCommand : BaseCommand
    {
        private AgentStayEatViewModel _model;
        private TouristFacilityService _service;
        private NavigationStore _navigationStore;

        public DeleteStayEatItemCommand(AgentStayEatViewModel model)
        {
            _model = model;
            _service = new TouristFacilityService();
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            var selectedItem = parameter as TouristFacilityListItemViewModel;
            if (selectedItem != null)
            {
                if (OpenMessageBox(selectedItem)) {
                    _service.FacilityRepository.DeleteItem(selectedItem.Id);                 
                    _model.FilteredItems.Remove(selectedItem);
                    _model.DeletedFacility = _service.FacilityRepository.GetById(selectedItem.Id);
                    MessageBox.Show("Deleted " + selectedItem.Type.ToString().ToLower() + " " + selectedItem.Name, "Successfully deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigationStore.CurrentViewModel = new AgentStayEatViewModel();
                    _model.SelectedItem = _model.FilteredItems[0];
                }
            } 
            else
                MessageBox.Show("By clicking on a restaurant or accommodation in the table, select an item to delete", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        // item is selected
        private bool OpenMessageBox(TouristFacilityListItemViewModel item)
        {
            MessageBoxResult result = MessageBox.Show("Delete the " + item.Type.ToString().ToLower() + " " + item.Name + " ?", "Delete " + item.Type.ToString().ToLower(), MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;

        }
    }
}
