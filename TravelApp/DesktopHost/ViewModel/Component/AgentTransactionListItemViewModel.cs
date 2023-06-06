using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DesktopHost.ViewModel
{
    public class AgentTransactionListItemViewModel
    {
        public int Id { get; set; }  // id of reservation from database
        public string Passenger { get; set; } 
        public string Trip { get; set; }  
        public string Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get; set; }
    }
}
