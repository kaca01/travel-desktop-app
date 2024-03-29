﻿using System;
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
    /// Interaction logic for ClientTripsView.xaml
    /// </summary>
    public partial class ClientTripsView : UserControl
    {
        public ClientTripsView()
        {
            InitializeComponent();
            SetHelpKey(null, null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            if (DataContext is ClientTripsViewModel viewModel)
            {
                if (windowWidth <= 1000)
                {
                    viewModel.FieldsWidth = 170;
                }
                else if (windowWidth <= 1100)
                {
                    viewModel.TextFontSize = 42;
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.FieldsWidth = 250;
                    viewModel.TextFontSize = 46;
                }
                else
                {
                    viewModel.FieldsWidth = 280;
                    viewModel.TextFontSize = 50;
                }
            }
        }

        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "allTrips");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void Open_Details(object sender, RoutedEventArgs e)
        {
            ClientTripsViewModel viewModel = (ClientTripsViewModel)DataContext;
            Button button = sender as Button;
            viewModel.SelectedTrip = ((int)button.CommandParameter);
            viewModel.TripDetails.Execute(this);
            
        }
    }
}
