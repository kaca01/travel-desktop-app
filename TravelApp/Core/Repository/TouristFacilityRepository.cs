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
        public List<TouristFacility> GetAll()
        {
            using (var context = new TravelContext())
            {
                return context.TouristFacilities.ToList();
            }
        }

        public TouristFacility GetById(int id)
        {
            using (var context = new TravelContext())
            {
                return context.TouristFacilities.First(u => u.Id == id);
            }
        }

        public List<string> GetAllNames()
        {
            using (var context = new TravelContext())
            {
                return context.TouristFacilities.Select(u => u.Name).ToList();
            }
        }

        public List<TouristFacilityListItemViewModel> Get()
        {
            using (var context = new TravelContext())
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
        }

        public void DeleteItem(int id) 
        {
            using (var context = new TravelContext())
            {
                TouristFacility facility = GetById(id);

                if (facility != null)
                {
                    facility.IsDeleted = true;
                    context.SaveChanges();
                }
            }
        }
    }
}
