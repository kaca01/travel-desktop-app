using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.Command.Agent.NewPlace
{
    public class CancelNewPlaceCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public CancelNewPlaceCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new AgentStayEatViewModel();
        }
    }
}
