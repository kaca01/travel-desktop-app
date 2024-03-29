﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TravelApp.Core.Service;

namespace TravelApp.DesktopHost.ViewModel.Component.ComboBox
{
    public class ComboBoxViewModel : BaseViewModel
    {
        private string _searchText;
        private ObservableCollection<ItemModel> _items;
        private ObservableCollection<ItemModel> _filteredItems;
        private int _selectedCount;
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

        public int SelectedCount
        {
            get { return _selectedCount; }
            set { _selectedCount = value; OnPropertyChanged(nameof(SelectedCount)); }
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
            data.ForEach(child => child.ValueChanged += Child_ValueChanged);
            Items = new ObservableCollection<ItemModel>(data);
            FilteredItems = Items;
            SelectedCount = 0;
            _itemsView = CollectionViewSource.GetDefaultView(FilteredItems);
        }

        public ItemModel FindById(int id)
        {
            List<ItemModel> list = Items.Where(u => u.Id == id).ToList();
            if (list.Count == 0) return null;
            return list[0];
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

        private void Child_ValueChanged(object sender, EventArgs e)
        {
            SelectedCount = Items.Where(item => item.IsSelected == true).Count();
        }

        public ObservableCollection<ItemModel> FilteredItems
        {
            get { return _filteredItems; }
            set { _filteredItems = value; OnPropertyChanged(nameof(FilteredItems)); }
        }
    }
}
