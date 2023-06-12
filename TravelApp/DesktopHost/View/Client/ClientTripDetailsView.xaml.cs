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
    /// Interaction logic for ClientTripDetailsView.xaml
    /// </summary>
    public partial class ClientTripDetailsView : UserControl
    {
        public ClientTripDetailsView()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeight = e.NewSize.Height;
            double scrollViewHeight = windowHeight - 50;

            if (DataContext is ClientTripDetailsViewModel viewModel)
            {
                viewModel.ScrollViewHeight = scrollViewHeight;
                if (windowWidth <= 1000)
                {
                    viewModel.FieldsWidth = 150;
                    viewModel.TextFontSize = 30;

                }
                else if (windowWidth <= 1100)
                {
                    viewModel.FieldsWidth = 170;
                    viewModel.TextFontSize = 35;
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.FieldsWidth = 200;
                    viewModel.TextFontSize = 46;
                }
                else
                {
                    viewModel.FieldsWidth = 280;
                    viewModel.TextFontSize = 50;
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            ClientTripDetailsViewModel viewModel = (ClientTripDetailsViewModel)DataContext;
            Button button = sender as Button;
            viewModel.Trips.Execute(this);

        }
    }
}
