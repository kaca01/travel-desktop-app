using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

namespace TravelApp.Core.Repository
{
    public class TripRepository : ITripRepository
    {
        TravelContext context = TravelContext.Instance;
        
        public List<Trip> GetAll()
        {
                return context.Trips.Where(t => !t.IsDeleted).ToList();
        }

        public Trip Get(int id)
        {
                return context.Trips.Where(u => u.Id == id).ToList()[0];

        }

        public bool Delete(int id)
        {
                Trip trip = context.Trips.Where(u => u.Id == id).ToList()[0];
            if (trip != null)
                {
                    trip.IsDeleted = true;
                    //todo check ig this works
                    return true;
                }
                return false;
        }

        private int generateId()
        {
            int max = 0;
            foreach (Trip t in context.Trips)
                if (t.Id > max) max = t.Id;

            return max + 1;
        }

        public Trip Create(NewTripViewModel vm, List<Attraction> attrcs, List<TouristFacility> tf)
        {
                Trip trip = new Trip() { Id = generateId(), Name = vm.Name, Description = vm.Description, Price = Double.Parse(vm.Price), Image = ImageConverter.ConvertImageSourceToByteArray(vm.ImageSource), Departure = vm.StartLocation, Destination = vm.EndLocation, StartDate = DateTime.Parse(vm.StartDate), EndDate = DateTime.Parse(vm.EndDate), IsDeleted = false };
                trip.Attractions = attrcs;
                trip.FacilityList = tf;
                context.Trips.Add(trip);
                return trip;
        }

        public List<TripListItemViewModel> GetAllReturnListItem()
        {
            return context.Trips.Select(t => new TripListItemViewModel
            {
                Id = t.Id,
                Name = t.Name,
                IsDeleted = t.IsDeleted
            }).Where(t => !t.IsDeleted).ToList();
        }
        public List<TouristFacilityListItemViewModel> GetTouristFacilities(int id)
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
            return null;
        }

        public List<Attraction> GetAttractions(int id)
        {
            
            Trip trip = context.Trips.First(item => item.Id == id);

            return trip.Attractions;
            
        }

    }
}
