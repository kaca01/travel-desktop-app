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
        public event PropertyChangedEventHandler PropertyChanged;

        private string _message = "";
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private bool _messageVisibility;

        public bool MessageVisibility
        {
            get { return _messageVisibility; }
            set
            {
                _messageVisibility = value;
                OnPropertyChanged(nameof(MessageVisibility));
            }
        }

        public void ShowMessage(string message, bool logOut = false)
        {
            Message = message;
            MessageVisibility = true;
            Wait(logOut);

        }

        public async void Wait(bool logOut)
        {
            await Task.Delay(3000);
            MessageVisibility = false;
            if (logOut)
            {
                NavigationStore.Instance().CurrentViewModel = new LoginViewModel();

            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
