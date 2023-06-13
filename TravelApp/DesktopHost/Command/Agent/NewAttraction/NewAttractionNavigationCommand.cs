using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command.Agent.NewAttraction
{
    public class NewAttractionNavigationCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        private AgentAttractionsViewModel _viewModel;

        public NewAttractionNavigationCommand(AgentAttractionsViewModel viewModel)
        {
            _navigation = NavigationStore.Instance();
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedAttraction > 0)
            {
                AttractionRepository repo = new AttractionRepository();
                Attraction a = repo.Get(_viewModel.SelectedAttraction);
                _viewModel.SelectedAttraction = -1;
                _navigation.CurrentViewModel = new NewAttractionViewModel(a);
            }
            else
            {
                _navigation.CurrentViewModel = new NewAttractionViewModel(null);
            }
        }
    }
}
