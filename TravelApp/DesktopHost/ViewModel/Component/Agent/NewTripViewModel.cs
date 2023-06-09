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
        private ICollectionView _itemsView;

        private Visibility _listVisibility;
        public Visibility ListVisibility
        {
            get => _listVisibility;
            set { _listVisibility = value; OnPropertyChanged(nameof(ListVisibility)); }
        }

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

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                _itemsView.Refresh();
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

        public NewTripViewModel()
        {
            ListVisibility = Visibility.Visible;
            IsButtonEnabled = false;
            Items = new ObservableCollection<ItemModel>
        {
            new ItemModel { Name = "Item 1" },
            new ItemModel { Name = "Item 2" },
            new ItemModel { Name = "Item 3" },
            // Add more items as needed
        };

            _itemsView = CollectionViewSource.GetDefaultView(Items);
            _itemsView.Filter = FilterItems;
        }

        private bool FilterItems(object obj)
        {
            var item = obj as ItemModel;
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            return item.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
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
