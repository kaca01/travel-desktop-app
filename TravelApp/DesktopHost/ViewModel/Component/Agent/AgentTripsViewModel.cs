using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.ViewModel.Component.Trip;

namespace TravelApp.DesktopHost.ViewModel
{
    class AgentTripsViewModel : BaseViewModel
    {
        private string _windowSize;

        private double _textFontSize;

        private List<string> _sortCriteria;

        public AgentNavigationViewModel Navigation { get; set; }

        public ICommand DisplayWindowSize { get; }

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

        public string WindowSize
        {
            get { return _windowSize; }
            set
            {
                _windowSize = value;
                OnPropertyChanged(nameof(WindowSize));
            }
        }

        public AgentTripsViewModel() 
        {
            _windowSize = "Dimenzije prozora";
            _textFontSize = 50;
            _sortCriteria = new List<string>();
            _sortCriteria.Add("All");
            _sortCriteria.Add("Trip name");
            _sortCriteria.Add("Departure location");
            _sortCriteria.Add("Destination location");
            _sortCriteria.Add("One day trip");
            _sortCriteria.Add("Multi days trip");
            Navigation = new AgentNavigationViewModel();
            DisplayWindowSize = new DisplayWidnowSizeCommand(this);
        }
    }
}
