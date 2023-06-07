using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Repository;
using TravelApp.Core.Service;

namespace TravelApp.DesktopHost.ViewModel 
{ 
    public class AgentReservationsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public AgentNavigationViewModel Navigation { get; set; }

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

        public AgentReservationsViewModel()
        {
            Navigation = new AgentNavigationViewModel();

            var dataService = new TransactionService();
            var data = dataService.GetReservations();
            Items = new ObservableCollection<TransactionListItemViewModel>(data);
            FilteredItems = new ObservableCollection<TransactionListItemViewModel>(Items);
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
