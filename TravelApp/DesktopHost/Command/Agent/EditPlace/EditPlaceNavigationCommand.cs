using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.Command.Agent.EditPlace
{
    public class EditPlaceNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public EditPlaceNavigationCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            var selectedItem = parameter as TouristFacilityListItemViewModel;
            _navigation.CurrentViewModel = new EditPlaceViewModel(selectedItem);
        }
    }
}
