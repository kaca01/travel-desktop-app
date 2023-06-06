using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AgentReservationsViewModel()
        {
            Navigation = new AgentNavigationViewModel();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
