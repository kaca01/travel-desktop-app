using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientReservationsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ClientNavigationViewModel Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private double _textSize;

        public double TextSize
        {
            get { return _textSize; }
            set
            {
                if (_textSize != value)
                {
                    _textSize = value;
                    OnPropertyChanged(nameof(TextSize));
                }
            }
        }

        private double _width;
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

        private double _tableWidth;

        public double TableWidth
        {
            get { return _tableWidth; }
            set
            {
                if (_tableWidth != value)
                {
                    _tableWidth = value;
                    OnPropertyChanged(nameof(TableWidth));
                }
            }
        }

        private Thickness _arrowMargin;
        public Thickness ArrowMargin
        {
            get { return _arrowMargin; }
            set
            {
                _arrowMargin = value;
                OnPropertyChanged(nameof(ArrowMargin));
            }
        }

        private ObservableCollection<TransactionListItemViewModel> _items;
        public ObservableCollection<TransactionListItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private ObservableCollection<TransactionListItemViewModel> _filteredItems;
        public ObservableCollection<TransactionListItemViewModel> FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                _filteredItems = value;
                OnPropertyChanged(nameof(FilteredItems));
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterData();
            }
        }

        private TransactionListItemViewModel _selectedItem;

        public TransactionListItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand Buy { get; set; }

        public ICommand CallOff { get; set; }

        public ClientReservationsViewModel()
        {
            Navigation = new ClientNavigationViewModel();

            var userService = new UserService();
            Items = new ObservableCollection<TransactionListItemViewModel>(userService.GetReservationsForCurrentUser());
            FilteredItems = new ObservableCollection<TransactionListItemViewModel>(Items);

            Buy = new BuyTripCommand(this);
            CallOff = new CallOffReservationCommand(this);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FilterData()
        {
            FilteredItems = new ObservableCollection<TransactionListItemViewModel>(Items.Where(item => item.Passenger.ToLower().Contains(SearchText.ToLower()) || item.Trip.ToLower().Contains(SearchText.ToLower()) || item.Price.Contains(SearchText.ToLower()) || item.StartDate.ToString().Contains(SearchText.ToLower()) || item.EndDate.ToString().Contains(SearchText.ToLower())));
        }
    }
}
