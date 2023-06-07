using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public List<TransactionListItemViewModel> GetReservationsForCurrentUser()
        {
            using (var context = new TravelContext())
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
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION") && t.User.Email.Equals("ines@gmail.com")).ToList();
            }
        }

        public List<TransactionListItemViewModel> GetTrips()
        {
            using (var context = new TravelContext())
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
                }).Where(t => !t.IsDeleted && t.Type.Equals("TRIP")).ToList();
            }
        }

        public List<TransactionListItemViewModel> GetTripsForCurrentUser()
        {
            using (var context = new TravelContext())
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
                }).Where(t => !t.IsDeleted && t.Type.Equals("TRIP") && t.User.Email.Equals("ines@gmail.com")).ToList();
            }
        }
    }
}
