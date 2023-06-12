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

        public CreateNewAttractionCommand(NewAttractionViewModel placeVM)
        {
            _service = new AttractionService();
            _placeVM = placeVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            try
            {
                Attraction tf = _service.Create(_placeVM);
                MessageBox.Show("Created attraction with name " + _placeVM.Name, "Successfully created", MessageBoxButton.OK, MessageBoxImage.Information);
                //_navigationStore.CurrentViewModel = new AgentAttractionViewModel();
                //todo uncomment
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
