﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for AgentNavigationView.xaml
    /// </summary>
    public partial class AgentNavigationView : UserControl
    {
        public int SelectedIndex { get => navigation.SelectedIndex; set => navigation.SelectedIndex = value; }

        public AgentNavigationView()
        {
            InitializeComponent();
            SetHelpKey(null, null);
            Help.Focus();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            // TODO : add here or and view model that you are using
            // note that you will need to add Navigation property in your view model
            if (DataContext is AgentTripsViewModel viewModel)
            {
                if (windowWidth <= 930)
                {
                    viewModel.Navigation.TextFontSize = 14;
                    viewModel.Navigation.TabWidth = windowWidth / 7; //125
                }
                else if (windowWidth <= 1100)
                {
                    viewModel.Navigation.TextFontSize = 15;
                    viewModel.Navigation.TabWidth = windowWidth / 7; //150
                }
                else if (windowWidth <= 1250)
                {
                    viewModel.Navigation.TextFontSize = 16;
                    viewModel.Navigation.TabWidth = windowWidth / 7; //180
                }
                else
                {
                    viewModel.Navigation.TextFontSize = 20;
                    viewModel.Navigation.TabWidth = windowWidth / 7; //220
                }
            }
            else if (DataContext is AgentStayEatViewModel vm)
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
            else if (DataContext is AgentReservationsViewModel reservationsViewModel)
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
        }

        public void Help_Click(object sender, EventArgs e)
        {
            var wnd = (MainWindow)Window.GetWindow(this);
            wnd.CommandBinding_Executed(sender, null);
        }

        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "index");
            }
        }
    }
}
