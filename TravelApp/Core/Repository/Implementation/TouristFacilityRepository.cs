using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Repository
{
    public class TouristFacilityRepository : ITouristFacilityRepository
    {
        TravelContext context = TravelContext.Instance;
        public List<TouristFacility> GetAll()
        {
            
                return context.TouristFacilities.ToList();
        }

        public TouristFacility GetById(int id)
        {
                return context.TouristFacilities.Where(u => u.Id == id).ToList()[0];
        }

        public List<string> GetAllNames()
        {
                return context.TouristFacilities.Select(u => u.Name).ToList();
       
        }

        public List<TouristFacilityListItemViewModel> Get()
        {
                return context.TouristFacilities.Select(t => new TouristFacilityListItemViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Address = t.Address,
                    Type = t.Type.ToString(),
                    Link = t.Link,
                    IsDeleted = t.IsDeleted
                }).Where(t => !t.IsDeleted).ToList();

        }

        public List<TouristFacility> GetValidRestaurants()
        {
                return context.TouristFacilities.Where(t => !t.IsDeleted && t.Type.Equals(PlaceType.RESTAURANT)).ToList();
           
        }

        public List<TouristFacility> GetValidAccomodations()
        {
                return context.TouristFacilities.Where(t => !t.IsDeleted && t.Type.Equals(PlaceType.ACCOMODATION)).ToList();
           
        }

        public void DeleteItem(int id) 
        {
                TouristFacility facility = GetById(id);

                if (facility != null)
                {
                    facility.IsDeleted = true;
                    //context.Update(facility);
                    //TODO CHECK THIS
                }
            
        }

        private int generateId()
        {
            int max = 0;
            foreach (TouristFacility tf in context.TouristFacilities)
                if (tf.Id > max) max = tf.Id;

            return max + 1;
        }

        public TouristFacility Create(string name, string address, string link, PlaceType type)
        {
                TouristFacility tf = new TouristFacility() { Id = generateId(), Name = name, Address = address, Link = link, Type = type };
                context.TouristFacilities.Add(tf);
                return tf;
        }
    }
}
