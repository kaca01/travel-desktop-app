using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelApp.Core.Service;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.DesktopHost.Command.Client
{
    public class BuyTripCommand : BaseCommand
    {
        private ClientReservationsViewModel _model;
        private TransactionService _service;

        public BuyTripCommand(ClientReservationsViewModel model)
        {
            _model = model;
            _service = new TransactionService();
        }

        public override void Execute(object parameter)
        {
            var selectedItem = parameter as TransactionListItemViewModel;
            if (selectedItem != null)
            {
                if (OpenMessageBox(selectedItem))
                {
                    _service.TransactionRepository.BuyTrip(selectedItem.Id);
                    _model.FilteredItems.Remove(selectedItem);
                    _model.CheckIsEnable();
                    MessageBox.Show("You bought the trip: " +
                                    "\nName: " + selectedItem.Trip +
                                    "\nPrice: " + selectedItem.Price +
                                    "\nStart Date: " + selectedItem.StartDate.ToShortDateString() +
                                    "\nEnd Date: " + selectedItem.EndDate.ToShortDateString(), "Successfully bought", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
                MessageBox.Show("By clicking on a trip in the table, select an item to buy", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool OpenMessageBox(TransactionListItemViewModel item)
        {
            MessageBoxResult result = MessageBox.Show("You want buy the trip ?" +
                                                        "\nName: " + item.Trip +
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
