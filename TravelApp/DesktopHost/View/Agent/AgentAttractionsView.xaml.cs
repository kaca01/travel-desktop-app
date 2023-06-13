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
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.Command.Agent.NewAttraction;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for AgentAttractionsView.xaml
    /// </summary>
    public partial class AgentAttractionsView : UserControl
    {
        public AgentAttractionsView()
        {
            InitializeComponent();
            SetHelpKey(null, null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            if (DataContext is AgentAttractionsViewModel viewModel)
            {
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            AgentAttractionsViewModel viewModel = (AgentAttractionsViewModel)DataContext;
            Button button = sender as Button;
            viewModel.Delete((int)button.CommandParameter);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            AgentAttractionsViewModel viewModel = (AgentAttractionsViewModel)DataContext;
            Button button = sender as Button;
            int id = ((int)button.CommandParameter);
            viewModel.SelectedAttraction = id;
            viewModel.NewAttraction.Execute(this);
        }
        
        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "allAttractionsAgent");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }
    }
}
