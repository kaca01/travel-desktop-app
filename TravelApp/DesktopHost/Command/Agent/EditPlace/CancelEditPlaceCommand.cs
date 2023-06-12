using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;
using System.Windows;

namespace TravelApp.DesktopHost.Command.Agent.EditPlace
{
    public class CancelEditPlaceCommand : BaseCommand
    {
        private readonly NavigationStore _navigation;

        public CancelEditPlaceCommand()
        {
            _navigation = NavigationStore.Instance();
        }
        public override void Execute(object parameter)
        {
            if(OpenMessageBox()) _navigation.CurrentViewModel = new AgentStayEatViewModel();
        }

        // item is selected
        private bool OpenMessageBox()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to quit? Your changes will not be saved!", "Quit edit place", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;

        }
    }
}
