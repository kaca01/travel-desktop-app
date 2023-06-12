using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Service;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ClientAttractionsViewModel : BaseViewModel
    {
        private AttractionService _attractionService;

        private double _textFontSize;

        private List<string> _sortCriteria;

        private List<Attraction> _attractions;

        private List<Attraction> _filteredAttractions;

        private string _search;

        private int _selectedSort;

        private int _selectedAttraction;

        private double _fieldsWidth;

        public ClientNavigationViewModel Navigation { get; set; }


        public List<string> SortCriteria
        {
            get { return _sortCriteria; }
            set
            {
                if (value != _sortCriteria)
                {
                    _sortCriteria = value;
                    OnPropertyChanged(nameof(SortCriteria));
                }
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

        public List<Attraction> Attractions
        {
            get { return _attractions; }
            set
            {
                _attractions = value;
                OnPropertyChanged(nameof(Attractions));
            }
        }

        public List<Attraction> FilteredAttractions
        {
            get { return _filteredAttractions; }
            set
            {
                _filteredAttractions = value;
                OnPropertyChanged(nameof(FilteredAttractions));
            }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                search();
            }
        }

        public int SelectedSort
        {
            get { return _selectedSort; }
            set
            {
                _selectedSort = value;
                OnPropertyChanged(nameof(SelectedSort));
                sort(SelectedSort);
            }
        }

        public int SelectedAttraction
        {
            get => _selectedAttraction;
            set
            {
                _selectedAttraction = value;
                OnPropertyChanged(nameof(SelectedAttraction));
            }
        }

        public double FieldsWidth
        {
            get => _fieldsWidth;
            set
            {
                _fieldsWidth = value;
                OnPropertyChanged(nameof(FieldsWidth));
            }
        }

        public ClientAttractionsViewModel()
        {
            _attractionService = new AttractionService();
            _textFontSize = 50;
            _sortCriteria = new List<string>();
            populateSortingCriteria();
            Navigation = new ClientNavigationViewModel();
            _attractions = new List<Attraction>();
            _filteredAttractions = new List<Attraction>();
            populateAttractions();
            FilteredAttractions = Attractions;
            _search = "";
            _selectedSort = 0;
        }

        private void populateSortingCriteria()
        {
            _sortCriteria.Add("Default");
            _sortCriteria.Add("Attraction name");
        }

        private void populateAttractions()
        {
            Attractions = _attractionService.GetAll();
        }

        private void sort(int criteria)
        {
            if (criteria == 0) FilteredAttractions = _attractions;

            else if (criteria == 1) FilteredAttractions = _filteredAttractions.OrderBy(obj => obj.Name).ToList();

        }

        private void search()
        {
            FilteredAttractions = new List<Attraction>(Attractions.Where(item => item.Name.ToLower().Contains(Search.ToLower())));
        }
    }
}
