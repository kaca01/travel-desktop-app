using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DesktopHost.ViewModel
{
    class AgentTripsViewModel : BaseViewModel
    {

        public AgentNavigationViewModel Navigation { get; set; }    

        public AgentTripsViewModel() 
        {
            Navigation = new AgentNavigationViewModel();

        }
    }
}
