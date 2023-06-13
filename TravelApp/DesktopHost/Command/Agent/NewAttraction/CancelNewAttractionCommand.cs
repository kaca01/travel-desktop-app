using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using System.Windows;

namespace TravelApp.DesktopHost.Command.Agent.NewAttraction
{
    class CancelNewAttractionCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public CancelNewAttractionCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to leave this page ?", "Leave page", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                _navigation.CurrentViewModel = new AgentAttractionsViewModel();
        }
    }
}
