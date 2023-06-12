using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.Trip;
using System.Windows;
using TravelApp.DesktopHost.Command.Agent;
using TravelApp.DesktopHost.Command.Agent.NewTrip;
using System.IO;
using System.Windows.Media.Imaging;
using TravelApp.Core;

namespace TravelApp.DesktopHost.ViewModel
{
    class AgentTripsViewModel : BaseViewModel
    {
        private ITripService _tripService;

        private string _windowSize;

        private double _textFontSize;

        private List<string> _sortCriteria;

        private List<Trip> _trips;

        private List<Trip> _searchedTrips;

        private string _search;

        private int _selectedSort;

        private int _selectedTrip;

        private double _fieldsWidth;

        public AgentNavigationViewModel Navigation { get; set; }

        public ICommand TripDetails { get; set; }

        public List<string> SortCriteria
        {
            get { return _sortCriteria; }
            set 
            { 
                if (value != _sortCriteria)
                {
                    _sortCriteria = value;
                    OnPropertyChanged(nameof(SortCriteria));
                }
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

        public string WindowSize
        {
            get { return _windowSize; }
            set
            {
                _windowSize = value;
                OnPropertyChanged(nameof(WindowSize));
            }
        }

        public List<Trip> Trips
        {
            get { return _trips; }
            set
            {
                _trips = value;
                OnPropertyChanged(nameof(Trips));
            }
        }

        public List<Trip> SearchedTrips
        {
            get { return _searchedTrips; }
            set
            {
                _searchedTrips = value;
                OnPropertyChanged(nameof(SearchedTrips));
            }
        }

        public string Search 
        { 
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                search();
            }
        }

        public int SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                _selectedSort = value;
                OnPropertyChanged(nameof(SelectedSort));
                sort(SelectedSort);
            }
        }

        public int SelectedTrip
        {
            get => _selectedTrip;
            set
            {
                _selectedTrip = value;
                OnPropertyChanged(nameof(SelectedTrip));
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

        public ICommand AddTripNavigation { get; }

        public AgentTripsViewModel() 
        {
            _tripService = new TripService();
            _windowSize = "Dimenzije prozora";
            _textFontSize = 50;
            _sortCriteria = new List<string>();
            populateSortingCriteria();
            Navigation = new AgentNavigationViewModel();
            TripDetails = new ClientTripDetailsCommand(this);
            _trips = new List<Trip>();
            _searchedTrips = new List<Trip>();
            populateTrips();
            _searchedTrips = getDesriptionTrips();
            _search = "";
            _selectedSort = 0;
            AddTripNavigation = new NewTripNavigationCommand();
        }

        private void populateSortingCriteria()
        {
            _sortCriteria.Add("Default");
            _sortCriteria.Add("Trip name");
            _sortCriteria.Add("Departure location");
            _sortCriteria.Add("Destination location");
        }

        private void populateTrips()
        {
            _trips = _tripService.GetAll();           
        }

        private List<Trip> getDesriptionTrips()
        {
            List<Trip> trips = new List<Trip>();
            foreach (Trip trip in _trips)
            {
                Trip t = new Trip();
                t.Id = trip.Id;
                t.IsDeleted = trip.IsDeleted;
                t.StartDate = trip.StartDate;
                t.EndDate = trip.EndDate;
                t.Price = trip.Price;
                t.Name = trip.Name;
                t.Departure = trip.Departure;
                t.Departure = trip.Destination;
                t.Image = trip.Image;
                t.Picture = ImageConverter.LoadPicture(trip.Image);
                t.Description = trip.Description.Substring(0, Math.Min(trip.Description.Length, 120)) + "...";
                trips.Add(t);
            }

            return trips;
        }

        private void sort(int criteria)
        {
            if (criteria == 0) SearchedTrips = getDesriptionTrips();

            else if (criteria == 1) SearchedTrips = _searchedTrips.OrderBy(obj => obj.Name).ToList();

            else if (criteria == 2) SearchedTrips = _searchedTrips.OrderBy(obj => obj.Departure).ToList();

            else if (criteria == 3) SearchedTrips = _searchedTrips.OrderBy(obj => obj.Destination).ToList();

     
        }

        private void search()
        {
            SearchedTrips = new List<Trip>(Trips.Where(item => item.Name.ToLower().Contains(Search.ToLower())));
        }

        public void Delete(int id)
        {
            SelectedTrip = id;
            Trip trip = _tripService.Get(SelectedTrip);
            if (openMessageBox(trip))
            {
                _tripService.Delete(SelectedTrip);
                _trips = _tripService.GetAll();
                SearchedTrips = getDesriptionTrips();
                MessageBox.Show("Deleted " + trip.Name + "!!!", "Successfully deleted", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private bool openMessageBox(Trip trip)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + trip.Name + " trip?", "Delete ", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;

        }


    }
}
