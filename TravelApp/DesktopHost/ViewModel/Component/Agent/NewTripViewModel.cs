using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command.Agent;
using TravelApp.DesktopHost.Command.Agent.NewTrip;
using TravelApp.DesktopHost.ViewModel.ComboBox;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;
using GalaSoft.MvvmLight.Command;
using System.Xaml;
using TravelApp.Core;
using TravelApp.Core.Model;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent
{
    public class NewTripViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        private string _startLocation;
        private string _endLocation;
        private string _startDate;
        private string _endDate;
        private string _price;
        private string _description;

        private double _textFontSize;
        private double _width;


        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); ValidationViewModel.IsNameValid(_name); CheckButtonStatus();
            }
        }

        public string StartLocation
        {
            get => _startLocation;
            set { _startLocation = value; OnPropertyChanged(nameof(StartLocation)); ValidationViewModel.IsSurnameValid(_startLocation); CheckButtonStatus(); 
            }
        }

        public string EndLocation
        {
            get => _endLocation;
            set { _endLocation = value; OnPropertyChanged(nameof(EndLocation)); ValidationViewModel.IsAddressValid(_endLocation); CheckButtonStatus();
            }
        }

        public string StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value; OnPropertyChanged(nameof(StartDate)); ValidationViewModel.IsStartDateValid(_startDate); CheckButtonStatus();
            }
        }

        public string EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value; OnPropertyChanged(nameof(EndDate)); ValidationViewModel.IsEndDateValid(_endDate); CheckButtonStatus();
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                _price = value; OnPropertyChanged(nameof(Price)); ValidationViewModel.IsPriceValid(_price); CheckButtonStatus();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value; OnPropertyChanged(nameof(Description)); ValidationViewModel.IsDescriptionValid(_description); CheckButtonStatus();
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


        private Visibility _imageVisibility;
        public Visibility ImageVisibility
        {
            get => _imageVisibility;
            set { _imageVisibility = value; OnPropertyChanged(nameof(ImageVisibility)); }
        }

        private BitmapImage _imageSource;

        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
                CheckButtonStatus();
            }
        }

        public ComboBoxViewModel Attractions { get; }
        public ComboBoxViewModel Accomodations { get; }
        public ComboBoxViewModel Restaurants { get; }

        public ICommand Cancel { get; }
        public ICommand Create { get; }
        public ICommand UploadImageCommand { get; }

        public ValidationViewModel ValidationViewModel { get; }

        public NewTripViewModel(TravelApp.Core.Model.Trip trip = null)
        {
            AttractionService attractionService = new AttractionService();
            TouristFacilityService tfService = new TouristFacilityService();
            Attractions = new ComboBoxViewModel(attractionService.GetItemModel());
            Accomodations = new ComboBoxViewModel(tfService.GetAccomodationsItemModel());
            Restaurants = new ComboBoxViewModel(tfService.GetRestaurantsItemModel());
            IsButtonEnabled = false;
            Cancel = new CancelNewTripCommand();
            Create = new CreateNewTripCommand(this);
            ValidationViewModel = new ValidationViewModel();
            UploadImageCommand = new RelayCommand(UploadImage);
            ImageVisibility = Visibility.Collapsed;

            if (trip != null)
            {
                ImageVisibility = Visibility.Visible;
                Name = trip.Name;
                Description = trip.Description;
                Price = trip.Price.ToString();
                StartDate = trip.StartDate.ToString();
                EndDate = trip.EndDate.ToString();
                ImageSource = ImageConverter.LoadPicture(trip.Image);
                StartLocation = trip.Departure;
                EndLocation = trip.Destination;

                foreach (Attraction attr in trip.Attractions)
                {
                    ItemModel a = Attractions.FindById(attr.Id);
                    a.IsSelected = true;
                }
                foreach (TouristFacility tf in trip.FacilityList)
                {
                    ItemModel a = Accomodations.FindById(tf.Id);
                    if (a != null)
                        a.IsSelected = true;
                }
                foreach (TouristFacility attr in trip.FacilityList)
                {
                    ItemModel a = Restaurants.FindById(attr.Id);
                    if (a != null)
                        a.IsSelected = true;
                }
            }
        }

        private void UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                // Display the image
                ImageVisibility = Visibility.Visible;
                ImageSource = new BitmapImage(new Uri(imagePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckButtonStatus()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_price) || string.IsNullOrWhiteSpace(_description) || 
                string.IsNullOrWhiteSpace(_startDate) || string.IsNullOrWhiteSpace(_endDate) ||
                string.IsNullOrWhiteSpace(_startLocation) || string.IsNullOrWhiteSpace(_endLocation))
                IsButtonEnabled = false;
            else
            {
                if (string.IsNullOrWhiteSpace(ValidationViewModel.NameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.SurnameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.AddressValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.StartDateValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.EndDateValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.PriceValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.DescriptionValidation) && ImageSource != null)
                    IsButtonEnabled = true;
                else
                {
                    IsButtonEnabled = false;
                }
            }
        }
    }
}
