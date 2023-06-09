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
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.DesktopHost.View.Agent
{
    /// <summary>
    /// Interaction logic for NewTripView.xaml
    /// </summary>
    public partial class NewTripView : UserControl
    {
        public NewTripView()
        {
            InitializeComponent();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            viewModel.ListVisibility = Visibility.Hidden;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NewTripViewModel viewModel = (NewTripViewModel)DataContext;
            viewModel.ListVisibility = Visibility.Visible;
        }
    }
}
