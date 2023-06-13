using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TravelApp.Core.Repository;
using TravelApp.Core.Repository.Implementation;
using TravelApp.Core.Repository.Interface;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.Core.Service
{
    public class TransactionService
    {
        private ITransactionRepository _transactionRepository;

        public ITransactionRepository TransactionRepository { get { return _transactionRepository; } }

        public TransactionService()
        {
            this._transactionRepository = new TransactionRepository();
        }

        public List<TransactionListItemViewModel> GetReservations()
        {
            return _transactionRepository.GetReservations();
        }

        public ObservableCollection<TransactionListItemViewModel> GetSoldTrips(int month, ObservableCollection<TripListItemViewModel> trips)
        {
            ObservableCollection<TransactionListItemViewModel> results = new ObservableCollection<TransactionListItemViewModel>();

            List<TransactionListItemViewModel> allTrips = _transactionRepository.GetTrips();

            foreach (TransactionListItemViewModel soldTrip in allTrips)
            {
                if (soldTrip.TransactionDate.Month != (month+1)) continue;
                if (trips == null) break; 
                foreach (TripListItemViewModel trip in trips)
                {
                    if (trip.Id == soldTrip.TripId) results.Add(soldTrip);
                }
            }
            return results;
        }

        public void BuyTrip(int id)
        {
            _transactionRepository.BuyTrip(id);
        }

        public void TripBooking(int id)
        {
            _transactionRepository.TripBooking(id);
        }


    }
}
