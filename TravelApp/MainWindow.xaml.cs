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

namespace TravelApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using(var db = new TravelContext())
{
                Console.WriteLine("Adding some authors into database...");
                User client = new User() { Name = "Roberto", Surname = "Bolano", Email = "roberto@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User agent = new User() { Name = "Mario", Surname = "Giordani", Email = "mario@gmail.com", Password = "pass1234", Role = Role.AGENT };
                db.Users.Add(client);
                db.Users.Add(agent);
                db.SaveChanges();
            }

            using (var context = new TravelContext())
            {
                var list = context.Users.ToList();
                System.Diagnostics.Trace.WriteLine(list);
            }

            InitializeComponent();
        }
    }
}
