using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command.Agent.EditPlace;
using TravelApp.DesktopHost.Command.Agent.NewPlace;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent.Form
{
    public class EditPlaceViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private string _link;

        private bool _restaurant;
        private bool _accomodation;

        private double _textFontSize;

        private double _width;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); ValidationViewModel.IsNameValid(_name); CheckButtonStatus(); setName(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); ValidationViewModel.IsAddressValid(_address); CheckButtonStatus(); setAddress(); }
        }

        public string Link
        {
            get => _link;
            set { _link = value; OnPropertyChanged(nameof(Link)); ValidationViewModel.IsLinkValid(_link); CheckButtonStatus(); setLink(); }
        }

        public bool Restaurant
        {
            get => _restaurant;
            set { _restaurant = value; OnPropertyChanged(nameof(Restaurant)); }
        }

        public bool Accomodation
        {
            get => _accomodation;
            set { _accomodation = value; OnPropertyChanged(nameof(Accomodation)); }
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

        private TouristFacilityListItemViewModel _editPlace;
        public TouristFacilityListItemViewModel EditPlace
        {
            get { return _editPlace; }
            set
            {
                _editPlace = value;
                OnPropertyChanged(nameof(EditPlace));
            }
        }

        public ICommand Cancel { get; }
        public ICommand Edit { get; }
        public ValidationViewModel ValidationViewModel { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckButtonStatus()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_address) || string.IsNullOrWhiteSpace(_link))
                IsButtonEnabled = false;
            else
            {
                if (string.IsNullOrWhiteSpace(ValidationViewModel.NameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.AddressValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.LinkValidation))
                    IsButtonEnabled = true;
                else
                {
                    IsButtonEnabled = false;
                }
            }
        }

        private void setName()
        {
            _editPlace.Name = Name;
        }

        private void setAddress()
        {
            _editPlace.Address = Address;
        }

        private void setLink()
        {
            _editPlace.Link = Link;
        }

        public EditPlaceViewModel()
        {
            Cancel = new CancelEditPlaceCommand();
            Edit = new EditPlaceCommand(this);
            ValidationViewModel = new ValidationViewModel();
            Restaurant = true;
            IsButtonEnabled = false;
        }

        public EditPlaceViewModel(TouristFacilityListItemViewModel editPlace)
        {
            ValidationViewModel = new ValidationViewModel();
            Restaurant = true;
            IsButtonEnabled = false;
            Cancel = new CancelEditPlaceCommand();
            Edit = new EditPlaceCommand(this);
            _editPlace = editPlace;
            Name = editPlace.Name;
            Address = editPlace.Address;
            Link = editPlace.Link;

            if (_editPlace.Type == "RESTAURANT")
            {
                Restaurant = true;
                Accomodation = false;
            }
            else
            {
                Restaurant = false;
                Accomodation = true;
            }
        }
    }
}
