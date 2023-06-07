using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Service;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientReservationsViewModel : BaseViewModel, INotifyPropertyChanged
    {

        // TODO promeni observable

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

        private ObservableCollection<AgentTransactionListItemViewModel> _items;
        public ObservableCollection<AgentTransactionListItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private ObservableCollection<AgentTransactionListItemViewModel> _filteredItems;
        public ObservableCollection<AgentTransactionListItemViewModel> FilteredItems
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

        private AgentTransactionListItemViewModel _selectedItem;

        public AgentTransactionListItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ClientReservationsViewModel()
        {
            Navigation = new ClientNavigationViewModel();

            var dataService = new TransactionService();
            var data = dataService.GetReservations();
            Items = new ObservableCollection<AgentTransactionListItemViewModel>(data);
            FilteredItems = new ObservableCollection<AgentTransactionListItemViewModel>(Items);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FilterData()
        {
            FilteredItems = new ObservableCollection<AgentTransactionListItemViewModel>(Items.Where(item => item.Passenger.ToLower().Contains(SearchText.ToLower()) || item.Trip.ToLower().Contains(SearchText.ToLower()) || item.Price.Contains(SearchText.ToLower()) || item.StartDate.Contains(SearchText.ToLower()) || item.EndDate.Contains(SearchText.ToLower())));
        }
    }
}
