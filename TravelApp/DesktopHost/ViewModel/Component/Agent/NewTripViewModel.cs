using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Linq;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.DesktopHost.ViewModel.Component.Agent
{
    public class NewTripViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _searchText;
        private ObservableCollection<ItemModel> _items;
        private ICollectionView _itemsView;

        private Visibility _listVisibility;
        public Visibility ListVisibility
        {
            get => _listVisibility;
            set { _listVisibility = value; OnPropertyChanged(nameof(ListVisibility)); }
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
            ListVisibility = Visibility.Hidden;
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
    }
}
