using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
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
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for AgentNavigationView.xaml
    /// </summary>
    public partial class AgentNavigationView : UserControl
    {
        public int SelectedIndex { get => navigation.SelectedIndex; set => navigation.SelectedIndex = value; }

        public AgentNavigationView()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;

            // TODO : add here else if and view model that you are using
            // note that you will need to add Navigation property in your view model
            if (DataContext is AgentTripsViewModel tripsViewModel)
            {
                adjustNavigationProperties(tripsViewModel.Navigation, windowWidth);
            }
            else if (DataContext is AgentAttractionsViewModel attractionsViewModel)
            {
                adjustNavigationProperties(attractionsViewModel.Navigation, windowWidth);
            }
        }

        private void adjustNavigationProperties(AgentNavigationViewModel navigation, double windowWidth)
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
