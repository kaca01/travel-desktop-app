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
using TravelApp.DesktopHost.ViewModel;

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


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // TODO : add here or and view model that you are using
            // note that you will need to add Navigation property in your view model
            if (DataContext is ClientTripsViewModel viewModel)      
            {
                if (windowWidth <= 930)
                {
                    viewModel.Navigation.TextFontSize = 14;
                    viewModel.Navigation.TabWidth = windowWidth / 7;
                }
                else if (windowWidth <= 1100)
                {
                    viewModel.Navigation.TextFontSize = 15;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.Navigation.TextFontSize = 16;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
                else
                {
                    viewModel.Navigation.TextFontSize = 20;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
            }
        }
    }
}
