using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TravelApp.Core;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command;
using TravelApp.DesktopHost.Command.Agent.NewTrip;
using TravelApp.DesktopHost.Command.Navigation;
using TravelApp.DesktopHost.Command.Navigation.Agent;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientTripDetailsViewModel : BaseViewModel
    {
        private double _textFontSize;

        private double _fieldsWidth;

        private double _descriptionWidth;

        private TripService _tripService;

        private Trip _trip;

        private ObservableCollection<TouristFacilityListItemViewModel> _facilities;

        private List<Attraction> _attractions;

        private double _scrollViewHeight;

        private double _tableWidth;

        private bool _isEnabled;

        private Visibility _buttonsVisibility;

        private Visibility _editVisibility;

        private Visibility _attractionsVisibility;

        private bool _clientNavEnabled;

        private bool _agentNavEnabled;

        public Visibility ButtonsVisibility
        {
            get => _buttonsVisibility;
            set { _buttonsVisibility = value; OnPropertyChanged(nameof(ButtonsVisibility)); }
        }

        public Visibility EditVisibility
        {
            get => _editVisibility;
            set { _editVisibility = value; OnPropertyChanged(nameof(EditVisibility)); }
        }
        public Visibility AttractionsVisibility
        {
            get => _attractionsVisibility;
            set { _attractionsVisibility = value; OnPropertyChanged(nameof(AttractionsVisibility)); }
        }

        public bool ClientNavEnabled
        {
            get => _clientNavEnabled;
            set
            {
                _clientNavEnabled = value;
                OnPropertyChanged(nameof(ClientNavEnabled));
            }
        }

        public bool AgentNavEnabled
        {
            get => _agentNavEnabled;
            set
            {
                _agentNavEnabled = value;
                OnPropertyChanged(nameof(AgentNavEnabled));
            }
        }


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

        public double FieldsWidth
        {
            get => _fieldsWidth;
            set
            {
                _fieldsWidth = value;
                OnPropertyChanged(nameof(FieldsWidth));
            }
        }

        public double DescriptionWidth
        {
            get => _descriptionWidth;
            set
            {
                _descriptionWidth = value;
                OnPropertyChanged(nameof(DescriptionWidth));
            }
        }

        public Trip Trip
        {
            get => _trip;
            set
            {
                _trip = value;
                OnPropertyChanged(nameof(Trip));
            }
        }

        public ObservableCollection<TouristFacilityListItemViewModel> Facilities
        {
            get { return _facilities; }
            set
            {
                _facilities = value;
                OnPropertyChanged(nameof(Facilities));
            }
        }

        public List<Attraction> Attractions
        {
            get { return _attractions; }
            set
            {
                _attractions = value;
                OnPropertyChanged(nameof(Attractions));
            }
        }

        public double ScrollViewHeight
        {
            get { return _scrollViewHeight; }
            set
            {
                _scrollViewHeight = value;
                OnPropertyChanged(nameof(ScrollViewHeight));
            }
        }

        public double TableWidth
        {
            get { return _tableWidth; }
            set
            {
                _tableWidth = value;
                OnPropertyChanged(nameof(TableWidth));
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }


        public BaseViewModel Navigation { get; set; }

        public ICommand Trips { get; set; }

        public ICommand Buy { get; set; }

        public ICommand Book { get; set; }

        public ICommand NewTrip { get; set; }

        public ICommand BackArrow { get; set; }


        public ClientTripDetailsViewModel(int selectedTrip)
        {
            if (UserService.CurrentUser.Role == Role.AGENT)
            {
                Navigation = new AgentNavigationViewModel();
                ButtonsVisibility = Visibility.Hidden;
                EditVisibility = Visibility.Visible;
                AgentNavEnabled = true;
                ClientNavEnabled = false;
            }
            else
            {
                Navigation = new ClientNavigationViewModel();
                ButtonsVisibility = Visibility.Visible;
                EditVisibility = Visibility.Hidden;
                AgentNavEnabled = false;
                ClientNavEnabled = true;
            }
            BackArrow = new ClientTripsCommand();
            if (UserService.CurrentUser.Role == Role.AGENT)
                BackArrow = new AgentTripsCommand();
            _tripService = new TripService();
            _trip = _tripService.Get(selectedTrip);
            _trip.Picture = ImageConverter.LoadPicture(_trip.Image);
            Trips = new ClientTripsCommand();
            Buy = new TripDetailsBuyCommand(this);
            Book = new TripDetailsReservationCommand(this);
            NewTrip = new NewTripNavigationCommand(this);

            List<TouristFacilityListItemViewModel> data = _tripService.GetTouristFacilities(_trip.Id);

            _facilities = new ObservableCollection<TouristFacilityListItemViewModel>(data);

            _attractions = _tripService.GetAttractions(selectedTrip);

            if (_attractions.Count > 0) AttractionsVisibility = Visibility.Hidden;
            else AttractionsVisibility = Visibility.Visible;
            
        }

       
    }
}
