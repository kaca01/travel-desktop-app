using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Service;

namespace TravelApp.DesktopHost.ViewModel
{
    public class AgentSoldTripsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public AgentNavigationViewModel Navigation { get; set; }

        private List<string> _pickMonth;

        private int _pickedMonth;

        public event PropertyChangedEventHandler PropertyChanged;

        private double _textSize;

        private double _width;

        private double _tableWidth;

        private Thickness _arrowMargin;

        private ObservableCollection<TransactionListItemViewModel> _items;

        private ObservableCollection<TransactionListItemViewModel> _filteredItems;

        public List<string> PickMonth
        {
            get { return _pickMonth; }
            set
            {
                if (value != _pickMonth)
                {
                    _pickMonth = value;
                    OnPropertyChanged(nameof(PickMonth));
                }
            }
        }

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
      
        public Thickness ArrowMargin
        {
            get { return _arrowMargin; }
            set
            {
                _arrowMargin = value;
                OnPropertyChanged(nameof(ArrowMargin));
            }
        }
       
        public ObservableCollection<TransactionListItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
       
        public ObservableCollection<TransactionListItemViewModel> FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                _filteredItems = value;
                OnPropertyChanged(nameof(FilteredItems));
            }
        }

        public int PickedMonth
        {
            get { return _pickedMonth; }
            set
            {
                _pickedMonth = value;
                OnPropertyChanged(nameof(PickedMonth));
            }
        }
        public AgentSoldTripsViewModel() 
        {
            Navigation = new AgentNavigationViewModel();

            var dataService = new TransactionService();
            var data = dataService.GetReservations();
            Items = new ObservableCollection<TransactionListItemViewModel>(data);
            FilteredItems = new ObservableCollection<TransactionListItemViewModel>(Items);

            _pickMonth = new List<string>();
            populateMonthList();
            _pickedMonth = 5;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void populateMonthList()
        {
            _pickMonth.Add("January");
            _pickMonth.Add("February");
            _pickMonth.Add("March");
            _pickMonth.Add("April");
            _pickMonth.Add("May");
            _pickMonth.Add("June");
            _pickMonth.Add("July");
            _pickMonth.Add("August");
            _pickMonth.Add("September");
            _pickMonth.Add("October");
            _pickMonth.Add("November");
            _pickMonth.Add("December");
        }
    }
}
