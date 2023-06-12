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
    /// Interaction logic for AgentStayEatView.xaml
    /// </summary>
    public partial class AgentStayEatView : UserControl
    {
        public AgentStayEatView()
        {
            InitializeComponent();
            DataContext = new AgentStayEatViewModel();
            SetHelpKey(null, null);
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

            // Adjust the font size based on the window width
            AgentStayEatViewModel viewModel = (AgentStayEatViewModel)DataContext;
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

            if (windowWidth <= 930) { viewModel.TableWidth = 650; viewModel.ArrowMargin = new Thickness(-10, 0, 0, 0); }
            else if (windowWidth <= 990) { viewModel.TableWidth = 700; viewModel.ArrowMargin = new Thickness(-20, 0, 0, 0); }
            else if (windowWidth <= 1250) { viewModel.TableWidth = 750; viewModel.ArrowMargin = new Thickness(-30, 0, 0, 0); }
            else { viewModel.TableWidth = 850; viewModel.ArrowMargin = new Thickness(-40, 0, 0, 0); }
        }

        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "stayAndEatAgent");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }
    }
}
