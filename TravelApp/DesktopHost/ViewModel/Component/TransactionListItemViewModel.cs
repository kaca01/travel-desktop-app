using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.DesktopHost.ViewModel
{
    public class TransactionListItemViewModel
    {
        public int Id { get; set; }  // id of reservation from database

        public int TripId { get; set; }
        public User User { get; set; }
        public string Passenger { get; set; } 
        public string Trip { get; set; }  
        public string Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
