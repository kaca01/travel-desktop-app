using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class ClientNavigationView : UserControl
    {
        public int SelectedIndex { get => navigation.SelectedIndex; set => navigation.SelectedIndex = value; }
        public ClientNavigationView()
        {
            InitializeComponent();
        }

        private void TabControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (SelectedIndex == 0)
                    BaseViewModel.ClientNavigationViewModel.Trips.Execute(null);
                else if (SelectedIndex == 1)
                    BaseViewModel.ClientNavigationViewModel.Attractions.Execute(null);
                else if (SelectedIndex == 2)
                    BaseViewModel.ClientNavigationViewModel.StayAndEat.Execute(null);
                else if (SelectedIndex == 3)
                    BaseViewModel.ClientNavigationViewModel.SoldTrips.Execute(null);
                else if (SelectedIndex == 4)
                    BaseViewModel.ClientNavigationViewModel.Reservations.Execute(null);
                else if (SelectedIndex == 5)
                    BaseViewModel.ClientNavigationViewModel.Help.Execute(null);
                else if (SelectedIndex == 6)
                    BaseViewModel.ClientNavigationViewModel.LogOut.Execute(null);
                // Mark the event as handled
                e.Handled = true;
            }
        }


        private UIElement FindFirstFocusableElement(DependencyObject element)
        {
            if (element == null)
                return null;

            if (element is UIElement uiElement && uiElement.Focusable)
                return uiElement;

            int childCount = VisualTreeHelper.GetChildrenCount(element);

            for (int i = 0; i < childCount; i++)
            {
                var childElement = VisualTreeHelper.GetChild(element, i);
                var result = FindFirstFocusableElement(childElement);

                if (result != null)
                    return result;
            }

            return null;
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;

            // TODO : add here else if and view model that you are using
            if (DataContext is ClientTripsViewModel tripsViewModel)      
            {
                adjustNavigationProperties(tripsViewModel.Navigation, windowWidth);
            }
            else if (DataContext is ClientAttractionsViewModel attractionsViewModel)
            {
                adjustNavigationProperties(attractionsViewModel.Navigation, windowWidth);
            }
            else if (DataContext is ClientTripDetailsViewModel tripDetailsViewModel)
            {
                if (UserService.CurrentUser.Role == Core.Model.Role.CLIENT)
                {
                    ClientNavigationViewModel vm = (ClientNavigationViewModel)tripDetailsViewModel.Navigation;
                    adjustNavigationProperties(vm, windowWidth);

                }
            }
            else if (DataContext is ClientStayEatViewModel stayEatViewModel)
            {
                adjustNavigationProperties(stayEatViewModel.Navigation, windowWidth);
            }
            else if (DataContext is ClientSoldTripsViewModel soldTripsViewModel)
            {
                adjustNavigationProperties(soldTripsViewModel.Navigation, windowWidth);
            }
            else if (DataContext is ClientReservationsViewModel reservationsViewModel)
            {
                adjustNavigationProperties(reservationsViewModel.Navigation, windowWidth);
            }
        }

        private void adjustNavigationProperties(ClientNavigationViewModel navigation, double windowWidth)
        {
            if (windowWidth <= 930)
            {
                navigation.TextFontSize = 14;
                navigation.TabWidth = windowWidth / 7;
            }
            else if (windowWidth <= 1100)
            {
                navigation.TextFontSize = 15;
                navigation.TabWidth = windowWidth / 7;
            }
            else if (windowWidth <= 1250)
            {
                navigation.TextFontSize = 16;
                navigation.TabWidth = windowWidth / 7;
            }
            else
            {
                navigation.TextFontSize = 20;
                navigation.TabWidth = windowWidth / 7;
            }
        }
    }
}
