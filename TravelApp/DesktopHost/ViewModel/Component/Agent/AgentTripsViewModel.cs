﻿using System;
using System.Collections.Generic;
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
            populateTrips("all");
        }

        private void populateSortingCriteria()
        {
            _sortCriteria.Add("All");
            _sortCriteria.Add("Trip name");
            _sortCriteria.Add("Departure location");
            _sortCriteria.Add("Destination location");
            _sortCriteria.Add("One day trip");
            _sortCriteria.Add("Multi days trip");
        }

        private void populateTrips(string criteria)
        {
            if (criteria == "all")
            {
                _trips = _tripService.getAll();
            }
        }

        private void sort(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
