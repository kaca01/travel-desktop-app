using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;

namespace TravelApp.DesktopHost.ViewModel.Component.ListItem
{
    public class TouristFacilityListItemViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public bool IsDeleted { get; set; }

    }
}
