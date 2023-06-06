using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command.Navigation;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientNavigationViewModel : BaseViewModel
    {
        private double _textFontSize;

        private double _tabWidth;

        public double TextFontSize
        {
            get { return _textFontSize; }
            set
            {
                if (_textFontSize != value)
                {
                    _textFontSize = value;
                    OnPropertyChanged(nameof(TextFontSize));
                }
            }
        }

        public double TabWidth
        {
            get { return _tabWidth; }
            set
            {
                if (_tabWidth != value)
                {
                    _tabWidth = value;
                    OnPropertyChanged(nameof(TabWidth));
                }
            }
        }

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
