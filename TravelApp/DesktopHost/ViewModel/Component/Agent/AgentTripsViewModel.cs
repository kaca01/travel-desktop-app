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

        public AgentNavigationViewModel Navigation { get; set; }

        public ICommand DisplayWindowSize { get; }

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
            Navigation = new AgentNavigationViewModel();
            DisplayWindowSize = new DisplayWidnowSizeCommand(this);
        }
    }
}
