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
using TravelApp.DesktopHost.Command.Navigation;

namespace TravelApp.DesktopHost.ViewModel
{
    public class AgentStayEatViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public AgentNavigationViewModel Navigation { get; set; }

        private ObservableCollection<TouristFacilityListItemViewModel> _items;
        public ObservableCollection<TouristFacilityListItemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private ObservableCollection<TouristFacilityListItemViewModel> _filteredItems;
        public ObservableCollection<TouristFacilityListItemViewModel> FilteredItems
        {
            get { return _filteredItems; }
            set
            {
                _filteredItems = value;
                OnPropertyChanged(nameof(FilteredItems));
            }
        }

        private TouristFacilityListItemViewModel _selectedItem;

        public TouristFacilityListItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand Delete { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

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

        public AgentStayEatViewModel()
        {
            Navigation = new AgentNavigationViewModel();
            var dataService = new TouristFacilityService();
            var data = dataService.GetTableData();

            Items = new ObservableCollection<TouristFacilityListItemViewModel>(data);
            FilteredItems = new ObservableCollection<TouristFacilityListItemViewModel>(Items);

            Delete = new DeleteStayEatItemCommand(this);

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FilterData()
        {
            FilteredItems = new ObservableCollection<TouristFacilityListItemViewModel>(Items.Where(item => item.Name.ToLower().Contains(SearchText.ToLower()) || item.Address.ToLower().Contains(SearchText.ToLower()) || item.Type.ToLower().Contains(SearchText.ToLower())));
        }
    }
}
