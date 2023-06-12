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
        TravelContext context = TravelContext.Instance;
        public List<TransactionListItemViewModel> GetReservations()
        {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION")).ToList();
            
        }

        public List<TransactionListItemViewModel> GetReservationsForCurrentUser()
        {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    IsDeleted = t.IsDeleted
                    // TODO promeni za trenutnog korisnika
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION") && t.User.Email.Equals("ines@gmail.com")).ToList();
         
        }

        public List<TransactionListItemViewModel> GetTrips()
        {
           
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate.Date,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE")).ToList();
            
        }

        public List<TransactionListItemViewModel> GetTripsForCurrentUser()
        {
                return context.Transactions.Select(t => new TransactionListItemViewModel
                {
                    Id = t.Id,
                    User = t.User,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate.Date,
                    EndDate = t.Trip.EndDate,
                    Type = t.Type.ToString(),
                    IsDeleted = t.IsDeleted
                    // TODO promeni za trenutnog korisnika
                }).Where(t => !t.IsDeleted && t.Type.Equals("PURCHASE") && t.User.Email.Equals("ines@gmail.com")).ToList();
            
        }

        public Transaction GetById(int id)
        {
            
                return context.Transactions.Where(u => u.Id == id).ToList()[0];

        }

        public void BuyTrip(int id)
        {
                Transaction transaction = GetById(id);

                if (transaction != null)
                {
                    transaction.Type = TransactionType.PURCHASE;
                //todo check if this works
                }
            
        }

        public void CallOffReservation(int id)
        {
                Transaction transaction = GetById(id);

                if (transaction != null)
                {
                    transaction.IsDeleted = true;
                    //todo check if this works
                }
        }
    }
}
