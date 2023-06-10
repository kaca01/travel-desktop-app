using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public List<TransactionListItemViewModel> GetReservations()
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    TripId = t.Trip.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    TransactionDate = t.TransactionDate,
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION")).ToList();
            }
        }

        public List<TransactionListItemViewModel> GetReservationsForCurrentUser(string currentUser)
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    TripId = t.Trip.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    TransactionDate = t.TransactionDate,
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION") && t.User.Email.Equals(currentUser)).ToList();
            }
        }

        public List<TransactionListItemViewModel> GetTrips()
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    TripId = t.Trip.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    TransactionDate = t.TransactionDate,
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE")).ToList();
            }
        }

        public List<TransactionListItemViewModel> GetTripsForCurrentUser(string currentUser)
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    TripId = t.Trip.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    TransactionDate = t.TransactionDate,
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE") && t.User.Email.Equals(currentUser)).ToList();
            }
        }

        public Transaction GetById(int id)
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.First(u => u.Id == id);
            }
        }

        public void BuyTrip(int id)
        {
            using (var context = new TravelContext())
            {
                Transaction transaction = GetById(id);

                if (transaction != null)
                {
                    transaction.Type = TransactionType.PURCHASE;
                    transaction.TransactionDate = DateTime.Now;
                    context.Update(transaction);
                    context.SaveChanges();
                }
            }
        }

        public void CallOffReservation(int id)
        {
            using (var context = new TravelContext())
            {
                Transaction transaction = GetById(id);

                if (transaction != null)
                {
                    transaction.IsDeleted = true;
                    context.Update(transaction);
                    context.SaveChanges();
                }
            }
        }
    }
}
