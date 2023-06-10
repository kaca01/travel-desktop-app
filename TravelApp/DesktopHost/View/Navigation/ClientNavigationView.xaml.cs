﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class ClientNavigationView : UserControl
    {
        public int SelectedIndex { get => navigation.SelectedIndex; set => navigation.SelectedIndex = value; }  
        public ClientNavigationView()
        {
            InitializeComponent();
        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // TODO : add here or and view model that you are using
            // note that you will need to add Navigation property in your view model
            if (DataContext is ClientTripsViewModel viewModel)      
            {
                if (windowWidth <= 930)
                {
                    viewModel.Navigation.TextFontSize = 14;
                    viewModel.Navigation.TabWidth = windowWidth / 7;
                }
                else if (windowWidth <= 1100)
                {
                    viewModel.Navigation.TextFontSize = 15;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.Navigation.TextFontSize = 16;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
                else
                {
                    viewModel.Navigation.TextFontSize = 20;
                    viewModel.Navigation.TabWidth = windowWidth / 7; 
                }
            }
            else if (DataContext is ClientStayEatViewModel vm)
            {
                if (windowWidth <= 930)
                {
                    vm.Navigation.TextFontSize = 14;
                    vm.Navigation.TabWidth = windowWidth / 7; //125
                }
                else if (windowWidth <= 1100)
                {
                    vm.Navigation.TextFontSize = 15;
                    vm.Navigation.TabWidth = windowWidth / 7; //150
                }
                else if (windowWidth <= 1250)
                {
                    vm.Navigation.TextFontSize = 16;
                    vm.Navigation.TabWidth = windowWidth / 7; //180
                }
                else
                {
                    vm.Navigation.TextFontSize = 20;
                    vm.Navigation.TabWidth = windowWidth / 7; //220
                }
            }
            else if (DataContext is ClientReservationsViewModel reservationsViewModel)
            {
                if (windowWidth <= 930)
                {
                    reservationsViewModel.Navigation.TextFontSize = 14;
                    reservationsViewModel.Navigation.TabWidth = windowWidth / 7; //125
                }
                else if (windowWidth <= 1100)
                {
                    reservationsViewModel.Navigation.TextFontSize = 15;
                    reservationsViewModel.Navigation.TabWidth = windowWidth / 7; //150
                }
                else if (windowWidth <= 1250)
                {
                    reservationsViewModel.Navigation.TextFontSize = 16;
                    reservationsViewModel.Navigation.TabWidth = windowWidth / 7; //180
                }
                else
                {
                    reservationsViewModel.Navigation.TextFontSize = 20;
                    reservationsViewModel.Navigation.TabWidth = windowWidth / 7; //220
                }
            }
            else if (DataContext is ClientSoldTripsViewModel soldTripsViewModel)
            {
                if (windowWidth <= 930)
                {
                    soldTripsViewModel.Navigation.TextFontSize = 14;
                    soldTripsViewModel.Navigation.TabWidth = windowWidth / 7; //125
                }
                else if (windowWidth <= 1100)
                {
                    soldTripsViewModel.Navigation.TextFontSize = 15;
                    soldTripsViewModel.Navigation.TabWidth = windowWidth / 7; //150
                }
                else if (windowWidth <= 1250)
                {
                    soldTripsViewModel.Navigation.TextFontSize = 16;
                    soldTripsViewModel.Navigation.TabWidth = windowWidth / 7; //180
                }
                else
                {
                    soldTripsViewModel.Navigation.TextFontSize = 20;
                    soldTripsViewModel.Navigation.TabWidth = windowWidth / 7; //220
                }
            }

        }
    }
}
