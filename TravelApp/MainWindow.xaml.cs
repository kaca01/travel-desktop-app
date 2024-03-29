﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using TravelApp.Core;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;

namespace TravelApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TravelContext context = TravelContext.Instance;
            new ConfigurationData().PopulateDataBase();

            // used to check if data has been properly added to database
            context = TravelContext.Instance;
           
                // add breakpoint and check if everything has been properly added
            List<User> users = context.Users.ToList();
            List<Attraction> attractions = context.Attractions.ToList();
            List<TouristFacility> facilities = context.TouristFacilities.ToList();
            List<Trip> trips = context.Trips.ToList();
            List<Transaction> transactions = context.Transactions.ToList();

            InitializeComponent();
        }

        public void doThings(string param) 
        { }

        public void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }
    }
}
