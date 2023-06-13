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
    public class CallOffReservationCommand : BaseCommand
    {
        private ClientReservationsViewModel _model;
        private TransactionService _service;

        public CallOffReservationCommand(ClientReservationsViewModel model)
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
                    _service.TransactionRepository.CallOffReservation(selectedItem.Id);
                    _model.FilteredItems.Remove(selectedItem);
                    _model.CheckIsEnable();
                    MessageBox.Show("You called off the trip: " +
                                    "\nName: " + selectedItem.Trip +
                                    "\nPrice: " + selectedItem.Price +
                                    "\nStart Date: " + selectedItem.StartDate.ToShortDateString() +
                                    "\nEnd Date: " + selectedItem.EndDate.ToShortDateString(), "Successfully call off", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
                MessageBox.Show("By clicking on a trip in the table, select an item to call off", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool OpenMessageBox(TransactionListItemViewModel item)
        {
            MessageBoxResult result = MessageBox.Show("You want call off the trip ?" +
                                                        "\nName: " + item.Trip +
                                                        "\nPrice: " + item.Price +
                                                        "\nStart Date: " + item.StartDate.ToShortDateString() +
                                                        "\nEnd Date: " + item.EndDate.ToShortDateString(), "Call off trip", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                return true;
            else
                return false;

        }
    }
}
