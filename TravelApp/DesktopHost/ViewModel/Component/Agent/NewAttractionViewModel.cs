using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TravelApp.Core;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.Command.Agent.NewAttraction;
using TravelApp.DesktopHost.Command.Agent.NewPlace;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent
{
    public class NewAttractionViewModel:BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private string _description;

        private double _textFontSize;

        private double _width;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); ValidationViewModel.IsNameValid(_name); CheckButtonStatus(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); ValidationViewModel.IsAddressValid(_address); CheckButtonStatus(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); ValidationViewModel.IsLinkValid(_description); CheckButtonStatus(); }
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

        private string _title;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); ValidationViewModel.IsNameValid(_title); CheckButtonStatus(); }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckButtonStatus()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_address) || string.IsNullOrWhiteSpace(_description))
                IsButtonEnabled = false;
            else
            {
                if (string.IsNullOrWhiteSpace(ValidationViewModel.NameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.AddressValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.DescriptionValidation) && ImageSource != null)
                    IsButtonEnabled = true;
                else
                {
                    IsButtonEnabled = false;
                }
            }
        }

        public ICommand Cancel { get; }
        public ICommand Create { get; }
        public ICommand UploadImageCommand { get; }
        public ValidationViewModel ValidationViewModel { get; }
        public Attraction Attraction { get; set; }

        public NewAttractionViewModel(Attraction attraction = null)
        {
            ValidationViewModel = new ValidationViewModel();

            Cancel = new CancelNewAttractionCommand();
            Create = new CreateNewAttractionCommand(this, attraction);
            IsButtonEnabled = false;
            ImageVisibility = Visibility.Collapsed;
            UploadImageCommand = new RelayCommand(UploadImage);
            Title = "New Attraction";

            if (attraction != null)
            {
                Name = attraction.Name;
                Address = attraction.Address;
                Description = attraction.Description;
                ImageSource = ImageConverter.LoadPicture(attraction.Image);
                ImageVisibility = Visibility.Visible;
                Title = "Update Attraction";
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

    }
}
