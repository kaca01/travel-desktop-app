using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

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
    }
}
