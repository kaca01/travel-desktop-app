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

namespace TravelApp.DesktopHost.View.Agent
{
    /// <summary>
    /// Interaction logic for NewPlaceView.xaml
    /// </summary>
    public partial class NewPlaceView : UserControl
    {
        public NewPlaceView()
        {
            InitializeComponent();
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // Adjust the font size based on the window width
            LoginViewModel viewModel = (LoginViewModel)DataContext;
            if (windowWidth <= 1200 || windowHeigth <= 700)
            {
                viewModel.TextFontSize = 40;
                viewModel.Width = 300;
            }
            else
            {
                viewModel.TextFontSize = 60;
                viewModel.Width = 439;
            }
        }
    }
}
