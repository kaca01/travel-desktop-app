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
        public List<AgentTransactionListItemViewModel> GetReservations()
        {
            using (var context = new TravelContext())
            {
                return context.Transactions.Select(t => new AgentTransactionListItemViewModel
                {
                    Id = t.Id,
                    Passenger = t.User.Name + " " + t.User.Surname,
                    Trip = t.Trip.Name,
                    Price = t.Trip.Price.ToString(),
                    StartDate = t.Trip.StartDate.ToShortDateString(),
                    EndDate = t.Trip.EndDate.ToShortDateString(),
                    Type = t.Type.ToString(),
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted && t.Type.Equals("RESERVATION")).ToList();
            }
        }
    }
}
