using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command.Navigation;
using TravelApp.DesktopHost.Command.Navigation.Agent;

namespace TravelApp.DesktopHost.ViewModel
{
    class AgentNavigationViewModel : BaseViewModel
    {
        public ICommand Trips { get; }
        public ICommand Attractions { get; }
        public ICommand StayAndEat { get; }
        public ICommand SoldTrips { get; }
        public ICommand Reservations { get; }
        public ICommand Help { get; }
        public ICommand LogOut { get; }

        public AgentNavigationViewModel() 
        {
            Trips = new AgentTripsCommand();
            Attractions = new AgentAttractionCommand();
            StayAndEat = new AgentStayAndEatCommand(); 
            SoldTrips = new AgentSoldTripsCommand();
            Reservations = new AgentReservationsCommand();
            Help = new AgentHelpCommand(); 
            LogOut = new LogOutCommand();
        }
    }
}
