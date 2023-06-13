using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        private SnackbarMessageQueue _snackbarMessageQueue;
        public static ClientNavigationViewModel ClientNavigationViewModel = new ClientNavigationViewModel();
        public static AgentNavigationViewModel AgentNavigationViewModel = new AgentNavigationViewModel();

        public SnackbarMessageQueue SnackbarMessageQueue
        {
            get { return _snackbarMessageQueue; }
            set
            {
                _snackbarMessageQueue = value;
                OnPropertyChanged(nameof(SnackbarMessageQueue));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
