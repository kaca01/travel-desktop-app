﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.DesktopHost.View
{
    /// <summary>
    /// Interaction logic for AgentSoldTripsView.xaml
    /// </summary>
    public partial class AgentSoldTripsView : UserControl
    {
        public AgentSoldTripsView()
        {
            InitializeComponent();
            DataContext = new AgentSoldTripsViewModel();
            SelectItem();
            SetHelpKey(null, null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;
            double windowHeigth = e.NewSize.Height;

            AgentSoldTripsViewModel viewModel = (AgentSoldTripsViewModel)DataContext;
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

            if (windowWidth <= 1100) { viewModel.TableWidth = 655; viewModel.ArrowMargin = new Thickness(0, 0, 0, 0); viewModel.SearchInputWidth = 200; }
            else if (windowWidth <= 1500) { viewModel.TableWidth = 850; viewModel.ArrowMargin = new Thickness(0, 0, 0, 0); viewModel.SearchInputWidth = 300; }
            else { viewModel.TableWidth = 900; viewModel.ArrowMargin = new Thickness(0, 0, 0, 0); viewModel.SearchInputWidth = 480; }
        }

        private void SelectItem()
        {
            AgentSoldTripsViewModel viewModel = (AgentSoldTripsViewModel)DataContext;
            myListBox.SelectedItems.Clear();
            foreach (var pickedTrip in viewModel.PickedTrips)
            {
                myListBox.SelectedItems.Add(pickedTrip);
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            var selectedItems = listBox.SelectedItems.Cast<TripListItemViewModel>().ToList();
            var viewModel = (AgentSoldTripsViewModel)DataContext;
            viewModel.PickedTrips = new ObservableCollection<TripListItemViewModel>(selectedItems);
        }

        public void SetHelpKey(object sender, EventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                HelpProvider.SetHelpKey((DependencyObject)focusedControl, "soldTrips");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }
    }
}
