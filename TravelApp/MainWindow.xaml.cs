using System;
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
            new ConfigurationData().PopulateDataBase();

            // used to check if data has been properly added to database
            /* using (var context = new TravelContext())
            {
                // add breakpoint and check if everything has been properly added
                List<Attraction> attractions = context.Attractions.ToList();
                List<TouristFacility> facilities = context.TouristFacilities.ToList();
                List<Trip> trips = context.Trips.ToList();
                
            }*/
            InitializeComponent();
        }
    }
}
