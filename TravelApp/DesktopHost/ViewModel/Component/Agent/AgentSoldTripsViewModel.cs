using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.DesktopHost.ViewModel
{
    public class AgentSoldTripsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public AgentNavigationViewModel Navigation { get; set; }

        private ObservableCollection<string> _pickMonth;       

        private int _pickedMonth;

        private double _totalPrice;

        private int _totalTrips; 

        public event PropertyChangedEventHandler PropertyChanged;

        private double _textSize;

        private double _width;

        private double _searchInputWidth;

        private double _tableWidth;

        private Thickness _arrowMargin;

        private ObservableCollection<TripListItemViewModel> _trips;

        private ObservableCollection<TripListItemViewModel> _filteredTrips;

        private ObservableCollection<TripListItemViewModel> _pickedTrips;

        private ObservableCollection<TransactionListItemViewModel> _tableData;

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

        public ObservableCollection<string> PickMonth
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

        public double TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public int TotalTrips
        {
            get { return _totalTrips; }
            set
            {
                if (value != _totalTrips)
                {
                    _totalTrips = value;
                    OnPropertyChanged(nameof(TotalTrips));
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

        public double SearchInputWidth
        {
            get { return _searchInputWidth; }
            set
            {
                if (_searchInputWidth != value)
                {
                    _searchInputWidth = value;
                    OnPropertyChanged(nameof(SearchInputWidth));
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
       
        public ObservableCollection<TripListItemViewModel> Trips
        {
            get { return _trips; }
            set
            {
                _trips = value;
                OnPropertyChanged(nameof(Trips));
            }
        }
       
        public ObservableCollection<TripListItemViewModel> FilteredTrips
        {
            get { return _filteredTrips; }
            set
            {
                _filteredTrips = value;
                OnPropertyChanged(nameof(FilteredTrips));
            }
        }

        public int PickedMonth
        {
            get { return _pickedMonth; }
            set
            {
                _pickedMonth = value;
                OnPropertyChanged(nameof(PickedMonth));
                TableData = ShowData();
                CalculateTotalPrice();
                TotalTrips = TableData.Count();
            }
        }

        public ObservableCollection<TripListItemViewModel> PickedTrips
        {
            get { return _pickedTrips; }
            set
            {
                if (value != _pickedTrips)
                {
                    _pickedTrips = value;
                    OnPropertyChanged(nameof(PickedTrips));
                    TableData = ShowData();
                    CalculateTotalPrice();
                    TotalTrips = TableData.Count();
                }
            }
        }

        public ObservableCollection<TransactionListItemViewModel> TableData
        {
            get { return _tableData; }
            set
            {
                if (value != _tableData)
                {
                    _tableData = value;
                    OnPropertyChanged(nameof(TableData));
                }
            }
        }

        public AgentSoldTripsViewModel() 
        {
            Navigation = new AgentNavigationViewModel();

            var tripService = new TripService();
            Trips = new ObservableCollection<TripListItemViewModel>(tripService.GetAllReturnListItem());
            FilteredTrips = new ObservableCollection<TripListItemViewModel>(Trips);
            PickedTrips = new ObservableCollection<TripListItemViewModel>(Trips);

            _pickMonth = new ObservableCollection<string>();
            populateMonthList();
            _pickedMonth = 5;

            TableData = ShowData();
            CalculateTotalPrice();
            TotalTrips = TableData.Count();
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

        private void FilterData()
        {
            FilteredTrips = new ObservableCollection<TripListItemViewModel>(Trips.Where(item => item.Name.ToLower().Contains(SearchText.ToLower())));
        }

        // todo stavi da vraca ObservableCollection<TransactionListItemViewModel>
        private ObservableCollection<TransactionListItemViewModel> ShowData()
        { 
            var transactionService = new TransactionService();
            return transactionService.GetSoldTrips(PickedMonth, PickedTrips);
        }

        private void CalculateTotalPrice()
        { 
            TotalPrice = 0;
            foreach (var item in TableData) 
            { 
                TotalPrice += Double.Parse(item.Price);
            }
        }
    }
}
