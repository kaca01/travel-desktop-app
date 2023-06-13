using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel.Component.Agent.Form;
using TravelApp.DesktopHost.ViewModel.Component.ListItem;

namespace TravelApp.Core.Repository
{
    public interface ITripRepository
    {
        public List<Trip> GetAll();

        public Trip Get(int id);

        public bool Delete(int id);

        public List<TouristFacilityListItemViewModel> GetTouristFacilities(int id);

        public List<Attraction> GetAttractions(int id);
        
        public Trip Create(NewTripViewModel vm, List<Attraction> attrcs, List<TouristFacility> tf);
        public List<TripListItemViewModel> GetAllReturnListItem();
    }
}
