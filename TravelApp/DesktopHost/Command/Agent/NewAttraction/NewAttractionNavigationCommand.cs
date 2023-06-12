using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Agent.NewAttraction
{
    //todo use in AgentAttracionViewModel
    public class NewAttractionNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public NewAttractionNavigationCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            _navigation.CurrentViewModel = new NewAttractionViewModel();
        }
    }
}
