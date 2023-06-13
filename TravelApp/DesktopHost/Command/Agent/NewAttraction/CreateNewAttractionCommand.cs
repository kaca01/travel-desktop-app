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

namespace TravelApp.DesktopHost.Command.Agent.NewAttraction
{
    public class CreateNewAttractionCommand : BaseCommand
    {
        private AttractionService _service;
        private readonly NavigationStore _navigationStore;
        private readonly NewAttractionViewModel _placeVM;
        private readonly Attraction _attraction;

        public CreateNewAttractionCommand(NewAttractionViewModel placeVM, Attraction attraction)
        {
            _attraction = attraction;
            _service = new AttractionService();
            _placeVM = placeVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                if (_attraction != null)
                { 
                    _service.Delete(_attraction.Id);
                    MessageBox.Show("Updated attraction with name " + _placeVM.Name, "Successfully updated", MessageBoxButton.OK, MessageBoxImage.Information);
                }else
                    MessageBox.Show("Created attraction with name " + _placeVM.Name, "Successfully created", MessageBoxButton.OK, MessageBoxImage.Information);
                Attraction tf = _service.Create(_placeVM);
                _navigationStore.CurrentViewModel = new AgentAttractionsViewModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
