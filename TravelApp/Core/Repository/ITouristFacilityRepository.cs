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
        public TouristFacility GetById(int id);
        public List<string> GetAllNames();
        public List<TouristFacilityListItemViewModel> Get();
        public void DeleteItem(int id);
        public TouristFacility Create(string name, string address, string link, PlaceType type);
    }
}
