using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.Core;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientTripsViewModel : BaseViewModel
    {
        private ITripService _tripService;

        private double _textFontSize;

        private List<string> _sortCriteria;

        private List<Trip> _trips;

        private List<Trip> _searchedTrips;

        private string _search;

        private int _selectedSort;

        private double _fieldsWidth;

        private int _selectedTrip;

        public ClientNavigationViewModel Navigation { get; set; }

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

        public double FieldsWidth
        {
            get => _fieldsWidth;
            set
            {
                _fieldsWidth = value;
                OnPropertyChanged(nameof(FieldsWidth));
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

        public ICommand TripDetails { get; set; }

        public ClientTripsViewModel()
        {
            // TODO : pass here which trip
            TripDetails = new ClientTripDetailsCommand(this);
            _tripService = new TripService();
            _textFontSize = 50;
            _sortCriteria = new List<string>();
            populateSortingCriteria();
            Navigation = new ClientNavigationViewModel();
            _trips = new List<Trip>();
            _searchedTrips = new List<Trip>();
            populateTrips();
            _searchedTrips = getDesriptionTrips();
            _search = "";
            _selectedSort = 0;
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
    }
}
