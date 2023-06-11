using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.DesktopHost.Command;

namespace TravelApp.DesktopHost.ViewModel.Component.Trip
{
    // TODO : delete this at the end of the project
    class DisplayWidnowSizeCommand : BaseCommand
    {
        private AgentTripsViewModel _agentTripsViewModel;

        public DisplayWidnowSizeCommand(AgentTripsViewModel agentTripsViewModel)
        {
            _agentTripsViewModel = agentTripsViewModel;
        }

        public override void Execute(object parameter)
        {
            int windowHeight = Convert.ToInt32(Application.Current.MainWindow.ActualHeight);
            int windowWidth = Convert.ToInt32(Application.Current.MainWindow.ActualWidth);
            _agentTripsViewModel.WindowSize = windowHeight.ToString() + " x " +  windowWidth.ToString();
        }
    }
}
