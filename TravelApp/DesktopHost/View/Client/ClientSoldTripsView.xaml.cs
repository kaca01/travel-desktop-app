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
    /// Interaction logic for ClientSoldTripsView.xaml
    /// </summary>
    public partial class ClientSoldTripsView : UserControl
    {
        public ClientSoldTripsView()
        {
            InitializeComponent();
            DataContext = new ClientSoldTripsViewModel();
            SetHelpKey(null, null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            ClientSoldTripsViewModel viewModel = (ClientSoldTripsViewModel)DataContext;
            if (windowWidth <= 1200 || windowHeigth <= 700)
            {
                viewModel.TextSize = 40;
                viewModel.Width = 300;
            }
            else
            {
                viewModel.TextSize = 60;
                viewModel.Width = 439;
            }

            if (windowWidth <= 930) { viewModel.TableWidth = 650; viewModel.ArrowMargin = new Thickness(-20, 0, 0, 0); }
            else if (windowWidth <= 1100) { viewModel.TableWidth = 700; viewModel.ArrowMargin = new Thickness(-30, 0, 0, 0); }
            else if (windowWidth <= 1250) { viewModel.TableWidth = 750; viewModel.ArrowMargin = new Thickness(-40, 0, 0, 0); }
            else { viewModel.TableWidth = 800; viewModel.ArrowMargin = new Thickness(-50, 0, 0, 0); }
        }

        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "myTrips");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }
    }
}
