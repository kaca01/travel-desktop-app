using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.Command.Agent
{
    public class CreateNewPlaceCommand : BaseCommand
    {
        private UserService _userService;
        private readonly NavigationStore _navigationStore;
        private readonly NewPlaceViewModel _placeVM;

        public CreateNewPlaceCommand(NewPlaceViewModel placeVM)
        {
            _userService = new UserService();
            _placeVM = placeVM;
            _navigationStore = NavigationStore.Instance();
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
