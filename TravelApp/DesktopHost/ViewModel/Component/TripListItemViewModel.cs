using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DesktopHost.ViewModel
{
    public class TripListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
