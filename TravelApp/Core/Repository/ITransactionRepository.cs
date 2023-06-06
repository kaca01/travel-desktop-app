using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public interface ITransactionRepository
    {
        public List<AgentTransactionListItemViewModel> GetReservations();
    }
}
