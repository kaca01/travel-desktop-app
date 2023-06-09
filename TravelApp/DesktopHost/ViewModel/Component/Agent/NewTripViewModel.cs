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
using System.Windows.Shapes;
using System.Xml.Linq;
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

        private string _searchText;
        private ObservableCollection<ItemModel> _items;
        private ObservableCollection<ItemModel> _filteredItems;
        private ICollectionView _itemsView;

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

        private bool _isDropDownOpen;
        public bool IsDropDownOpen
        {
            get { return _isDropDownOpen; }
            set { _isDropDownOpen = value; OnPropertyChanged(nameof(IsDropDownOpen)); }
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

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                FilterItems();
                OnPropertyChanged(nameof(SearchText));
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

        public ObservableCollection<ItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ObservableCollection<ItemModel> FilteredItems
        {
            get { return _filteredItems; }
            set { _filteredItems = value; OnPropertyChanged(nameof(FilteredItems)); }
        }

        public NewTripViewModel()
        {
            IsButtonEnabled = false;
            Items = new ObservableCollection<ItemModel>
        {
            new ItemModel { Name = "Item 1" },
            new ItemModel { Name = "Item 2" },
            new ItemModel { Name = "Item 3" },
            // Add more items as needed
        };
            FilteredItems = Items;
            _itemsView = CollectionViewSource.GetDefaultView(FilteredItems);
        }

        private void FilterItems()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredItems = Items;
            }
            else
            {
                FilteredItems = new ObservableCollection<ItemModel>(Items.Where(item => item.Name.ToLower().Contains(SearchText.ToLower())));
            }
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
