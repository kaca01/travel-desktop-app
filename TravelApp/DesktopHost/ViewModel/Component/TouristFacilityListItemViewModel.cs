using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;

namespace TravelApp.DesktopHost.ViewModel
{
    public class TouristFacilityListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        
    }
}
