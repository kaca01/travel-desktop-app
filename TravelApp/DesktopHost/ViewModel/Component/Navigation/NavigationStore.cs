using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DesktopHost.ViewModel.Navigation
{
    public class NavigationStore
    {

        private static NavigationStore instance;
        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        protected NavigationStore()
        {
        }

        public static NavigationStore Instance()
        {
            if (instance is null)
            {
                instance = new NavigationStore();
            }
            return instance;
        }


        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
