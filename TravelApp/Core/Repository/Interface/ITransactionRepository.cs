using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.Core.Repository.Interface
{
    public interface ITransactionRepository
    {
        public List<TransactionListItemViewModel> GetReservations();
        public List<TransactionListItemViewModel> GetReservationsForCurrentUser(string currentUser);
        public List<TransactionListItemViewModel> GetTrips();
        public List<TransactionListItemViewModel> GetTripsForCurrentUser(string currentUser);
        public Transaction GetById(int id);
        public void BuyTrip(int id);
        public void CallOffReservation(int id);
        public void TripBooking(int id);
    }
}
