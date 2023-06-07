using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TravelApp.DesktopHost.ViewModel.Component;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for ClientStayEatView.xaml
    /// </summary>
    public partial class ClientStayEatView : UserControl
    {
        public ClientStayEatView()
        {
            InitializeComponent();
            DataContext = new ClientStayEatViewModel();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string url = e.Uri.AbsoluteUri;
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            Process.Start(psi);
            e.Handled = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            ClientStayEatViewModel viewModel = (ClientStayEatViewModel)DataContext;
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

            if (windowWidth <= 930) { viewModel.TableWidth = 500; viewModel.ArrowMargin = new Thickness(-20, 0, 0, 0); }
            else if (windowWidth <= 1100) { viewModel.TableWidth = 600; viewModel.ArrowMargin = new Thickness(-30, 0, 0, 0); }
            else if (windowWidth <= 1250) { viewModel.TableWidth = 750; viewModel.ArrowMargin = new Thickness(-40, 0, 0, 0); }
            else { viewModel.TableWidth = 800; viewModel.ArrowMargin = new Thickness(-55, 0, 0, 0); }
        }
    }
}
