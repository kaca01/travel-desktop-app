using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.Trip;

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

        public AgentNavigationViewModel Navigation { get; set; }

        public ICommand DisplayWindowSize { get; }

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

        public AgentTripsViewModel() 
        {
            _tripService = new TripService();
            _windowSize = "Dimenzije prozora";
            _textFontSize = 50;
            _sortCriteria = new List<string>();
            populateSortingCriteria();
            Navigation = new AgentNavigationViewModel();
            DisplayWindowSize = new DisplayWidnowSizeCommand(this);
            _trips = new List<Trip>();
            _searchedTrips = new List<Trip>();
            populateTrips("all");
            _searchedTrips = _trips;
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

        private void populateTrips(string criteria)
        {
            if (criteria == "all")
            {
                _trips = _tripService.getAll();
            }
        }

        private void sort(int criteria)
        {
            if (criteria == 0) SearchedTrips = _trips;
            
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
