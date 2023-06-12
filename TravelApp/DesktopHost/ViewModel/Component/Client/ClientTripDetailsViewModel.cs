﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command.Navigation;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientTripDetailsViewModel : BaseViewModel
    {
        private double _textFontSize;

        private double _fieldsWidth;

        private ITripService _tripService;

        private Trip _trip;

        private ObservableCollection<TouristFacilityListItemViewModel> _facilities;

        private List<Attraction> _attractions;

        private double _scrollViewHeight;

        private double _tableWidth;

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


        public ClientNavigationViewModel Navigation { get; set; }

        public ICommand Trips { get; set; }


        public ClientTripDetailsViewModel(int selectedTrip)
        {
            Navigation = new ClientNavigationViewModel();
            _tripService = new TripService();
            _trip = _tripService.Get(selectedTrip);
            Trips = new ClientTripsCommand();

            List<TouristFacilityListItemViewModel> data = _tripService.GetTouristFacilities(_trip.Id);

            // TODO : delete this after fixing the problem with database
            //ITouristFacilityRepository repo = new TouristFacilityRepository();
            //var data = repo.Get();

            Facilities = new ObservableCollection<TouristFacilityListItemViewModel>(data);

            _attractions = _tripService.GetAttractions(selectedTrip);

            // TODO : dele this after fixing database
            //AttractionService attractionService = new AttractionService();
            //Attractions = attractionService.GetAll();
        }
    }
}
