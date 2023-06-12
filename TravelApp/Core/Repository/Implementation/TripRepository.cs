using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

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

        public Trip Create(NewTripViewModel vm, List<Attraction> attrcs, List<TouristFacility> tf)
        {
            using (var context = new TravelContext())
            {

                Trip trip = new Trip() { Name = vm.Name, Description = vm.Description, Price = Double.Parse(vm.Price), Image = ImageConverter.ConvertImageSourceToByteArray(vm.ImageSource), Departure = vm.StartLocation, Destination = vm.EndLocation, StartDate = DateTime.Parse(vm.StartDate), EndDate = DateTime.Parse(vm.EndDate), IsDeleted = false };
                trip.Attractions = attrcs;
                trip.FacilityList = tf;
                context.Trips.Add(trip);
                context.SaveChanges();
                return trip;
            }
        }
    }
}
