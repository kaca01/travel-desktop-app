using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public interface ITouristFacilityRepository
    {
        public List<TouristFacility> GetAll();
        public List<string> GetAllNames();
        public List<TouristFacilityListItemViewModel> Get();

    }
}
