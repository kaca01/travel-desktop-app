using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TravelApp.DesktopHost.Command;
using TravelApp.DesktopHost.Command.Agent;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent
{
    public class NewPlaceViewModel :BaseViewModel, INotifyPropertyChanged
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
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(nameof(Address)); }
        }

        public string Link
        {
            get => _link;
            set { _link = value; OnPropertyChanged(nameof(Link)); }
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

        public ICommand Cancel { get; }
        public ICommand Create { get; }
        public ValidationViewModel ValidationViewModel { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewPlaceViewModel()
        {
            Cancel = new CancelNewPlaceCommand();
            Create = new CreateNewPlaceCommand(this);
            ValidationViewModel = new ValidationViewModel();
            Restaurant = true;
        }

    }
}
