using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public class TripRepository : ITripRepository
    {
        public List<Trip> GetAll()
        {
            using (var context = new TravelContext())
            {
                return context.Trips.Where(t => !t.IsDeleted).ToList();
            }
        }

        public Trip Get(int id)
        {
            using (var context = new TravelContext())
            {
                return context.Trips.First(t => t.Id == id);
            }
        }

        public bool Delete(int id)
        {
            using (var context = new TravelContext())
            {
                Trip trip = context.Trips.First(t => t.Id == id);
                if (trip != null)
                {
                    trip.IsDeleted = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<TouristFacilityListItemViewModel> GetTouristFacilities(int id)
        {
            using (var context = new TravelContext())
            {
                Trip trip = context.Trips.First(item => item.Id == id);

                if (trip != null)
                {
                    if (trip.FacilityList != null)
                    // Iterate through the property that is also a list and create a new object for each item
                    {
                        List<TouristFacilityListItemViewModel> facilities =
                        trip.FacilityList.Select(item => new TouristFacilityListItemViewModel
                        {
                            // Set properties of the new object based on the item from the property list
                            Id = item.Id,
                            Name = item.Name,
                            Address = item.Address,
                            Type = item.Type.ToString(),
                            Link = item.Link,
                            IsDeleted = item.IsDeleted
                        }).Where(item => !item.IsDeleted).ToList();

                        return facilities;

                    }                    
                }

            }
            return null;
        }

    }
}
