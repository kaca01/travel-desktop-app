using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Database;
using TravelApp.DesktopHost.ViewModel.Navigation;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //private readonly Institution _institution;
        private readonly NavigationStore _navigation;
        public App()
        {
            /*AppConfiguration.SetInstance(FileService.Deserialize<AppConfiguration>("../../../Infrastructure/Database/Data/databasePaths.json")[0]);

            _institution = Institution.Instance();*/

            _navigation = NavigationStore.Instance();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigation.CurrentViewModel = new LoginViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigation)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //_institution.SaveAll();
            base.OnExit(e);
        }
    }
}
