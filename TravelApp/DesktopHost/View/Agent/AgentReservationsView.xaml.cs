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
    /// Interaction logic for AgentReservationsView.xaml
    /// </summary>
    public partial class AgentReservationsView : UserControl
    {
        public AgentReservationsView()
        {
            InitializeComponent();
            DataContext = new AgentReservationsViewModel();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            AgentReservationsViewModel viewModel = (AgentReservationsViewModel)DataContext;
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

            if (windowWidth <= 930) viewModel.TableWidth = 500;
            else if (windowWidth <= 1100) viewModel.TableWidth = 600;
            else if (windowWidth <= 1250) viewModel.TableWidth = 750;
            else viewModel.TableWidth = 800;
        }
    }
}
