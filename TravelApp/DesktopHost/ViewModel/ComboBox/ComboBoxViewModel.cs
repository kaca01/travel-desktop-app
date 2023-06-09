using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.DesktopHost.ViewModel.ComboBox
{
    public class ComboBoxViewModel : BaseViewModel
    {
        private string _searchText;
        private ObservableCollection<ItemModel> _items;
        private ObservableCollection<ItemModel> _filteredItems;
        private ICollectionView _itemsView;
        private bool _isDropDownOpen;

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

        public bool IsDropDownOpen
        {
            get { return _isDropDownOpen; }
            set { _isDropDownOpen = value; OnPropertyChanged(nameof(IsDropDownOpen)); }
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

        public ComboBoxViewModel(List<ItemModel> data) 
        {
            Items = new ObservableCollection<ItemModel>(data);
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

        public ObservableCollection<ItemModel> FilteredItems
        {
            get { return _filteredItems; }
            set { _filteredItems = value; OnPropertyChanged(nameof(FilteredItems)); }
        }
    }
}
