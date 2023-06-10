using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Xml.Linq;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command.Agent;
using TravelApp.DesktopHost.Command.Agent.NewTrip;
using TravelApp.DesktopHost.ViewModel.ComboBox;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent
{
    public class NewTripViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        private string _startLocation;
        private string _endLocation;


        private double _textFontSize;
        private double _width;


        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); //ValidationViewModel.IsNameValid(_name); CheckButtonStatus();
            }
        }

        public string StartLocation
        {
            get => _startLocation;
            set { _startLocation = value; OnPropertyChanged(nameof(StartLocation)); //ValidationViewModel.IsStartLocationValid(_startLocation); CheckButtonStatus(); 
            }
        }

        public string EndLocation
        {
            get => _endLocation;
            set { _endLocation = value; OnPropertyChanged(nameof(EndLocation)); //ValidationViewModel.IsEndLocationValid(_endLocation); CheckButtonStatus();
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

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }

        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public ComboBoxViewModel Attractions { get; }
        public ComboBoxViewModel Accomodations { get; }
        public ComboBoxViewModel Restaurants { get; }

        public ICommand Cancel { get; }
        public ICommand Create { get; }

        public NewTripViewModel()
        {
            AttractionService attractionService = new AttractionService();
            TouristFacilityService tfService = new TouristFacilityService();
            Attractions = new ComboBoxViewModel(attractionService.GetItemModel());
            Accomodations = new ComboBoxViewModel(tfService.GetAccomodationsItemModel());
            Restaurants = new ComboBoxViewModel(tfService.GetRestaurantsItemModel());
            IsButtonEnabled = false;
            Cancel = new CancelNewTripCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckButtonStatus()
        {
            //todo implement
        }
    }
}
