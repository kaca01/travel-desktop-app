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
    /// Interaction logic for AgentTripsView.xaml
    /// </summary>
    public partial class AgentTripsView : UserControl
    {
        public AgentTripsView()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            if (DataContext is AgentTripsViewModel viewModel)
            {
                if (windowWidth <= 1100)
                {
                    viewModel.TextFontSize = 42;
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.TextFontSize = 46;
                }
                else
                {
                    viewModel.TextFontSize = 50;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedItem is string selectedItem)
                {
                    string selectedContent = selectedItem.ToString();
                    // TODO : imeplement this
                }
            }
        }
    }
}
