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
            double windowHeigth = e.NewSize.Height;

            // Adjust the font size based on the window width
            // TODO : how to make this generic ????
            AgentTripsViewModel viewModel = (AgentTripsViewModel)DataContext;
            if (windowWidth <= 930)
            {
                viewModel.Navigation.TextFontSize = 14;
                viewModel.Navigation.TabWidth = windowWidth / 7; //125
            }
            else if (windowWidth <= 1100)
            {
                viewModel.Navigation.TextFontSize = 15;
                viewModel.Navigation.TabWidth = windowWidth / 7; //150
            }
            else if (windowWidth <= 1250)
            {
                viewModel.Navigation.TextFontSize = 16;
                viewModel.Navigation.TabWidth = windowWidth/7; //180
            }
            else
            {
                viewModel.Navigation.TextFontSize = 20;
                viewModel.Navigation.TabWidth = windowWidth/7; //220
            }
        }
    }
}
