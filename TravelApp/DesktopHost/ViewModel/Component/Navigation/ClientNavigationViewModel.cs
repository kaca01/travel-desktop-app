using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command.Navigation;

namespace TravelApp.DesktopHost.ViewModel
{
    class ClientNavigationViewModel : BaseViewModel
    {
        public ICommand Trips { get; }
        public ICommand Attractions { get; }
        public ICommand StayAndEat { get; }
        public ICommand SoldTrips { get; }
        public ICommand Reservations { get; }
        public ICommand Help { get; }
        public ICommand LogOut { get; }

        public ClientNavigationViewModel() 
        {
            Trips = new ClientTripsCommand();
            Attractions = new ClientAttractionCommand();
            StayAndEat = new ClientStayAndEatCommand();
            SoldTrips = new ClientSoldTripsCommand();
            Reservations = new ClientReservationsCommand(); 
            Help = new ClientHelpCommand();
            LogOut = new LogOutCommand();  
        }
    }
}
