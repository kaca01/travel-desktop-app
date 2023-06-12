using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Navigation.Agent
{
    class AgentAttractionCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public AgentAttractionCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            if (_navigation.CurrentViewModel.GetType() != typeof(AgentAttractionsViewModel))
                _navigation.CurrentViewModel = new AgentAttractionsViewModel();
        }
    }
}
