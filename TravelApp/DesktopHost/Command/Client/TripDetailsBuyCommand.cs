using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Model;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.DesktopHost.Command
{
    class TripDetailsBuyCommand : BaseCommand
    {
        private ClientTripDetailsViewModel _viewModel;

        private TransactionService _service;

        private readonly NavigationStore _navigation;

        public TripDetailsBuyCommand(ClientTripDetailsViewModel viewModel) {
            _viewModel = viewModel;
            _navigation = NavigationStore.Instance();
            _service = new TransactionService();
        }

        public override void Execute(object parameter)
        {
            Trip trip = _viewModel.Trip;

            if (openMessageBox(trip))
            {
                _service.BuyTrip(trip.Id);
                MessageBox.Show("You bought the trip: " +
                                "\nName: " + trip.Name +
                                "\nPrice: " + trip.Price +
                                "\nStart Date: " + trip.StartDate.ToShortDateString() +
                                "\nEnd Date: " + trip.EndDate.ToShortDateString() +
                                "\nCheck it out in section My Reservations!", "Successfully bought.", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.CurrentViewModel = new ClientTripsViewModel();

            }
        }

        private bool openMessageBox(Trip item)
        {
            MessageBoxResult result = MessageBox.Show("You want buy the trip ?" +
                                                        "\nName: " + item.Name +
                                                        "\nPrice: " + item.Price +
                                                        "\nStart Date: " + item.StartDate.ToShortDateString() +
                                                        "\nEnd Date: " + item.EndDate.ToShortDateString(), "Buy trip", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;

        }
    }
}
