using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.Core.Service
{
    internal class TripService : ITripService
    {
        private ITripRepository _tripRepository;
        private ITouristFacilityRepository _facilityRepository;
        private IAttractionRepository _attractionRepository;

        public TripService()
        {
            _tripRepository = new TripRepository();
            _attractionRepository = new AttractionRepository();
            _facilityRepository = new TouristFacilityRepository();
        }

        public List<Trip> GetAll()
        {
            return _tripRepository.GetAll();
        }

        public Trip Get(int id)
        {
            return _tripRepository.Get(id);
        }

        public bool Delete(int id)
        {
            return _tripRepository.Delete(id);
        }

        public List<TouristFacilityListItemViewModel> GetTouristFacilities(int id)
        {
            return _tripRepository.GetTouristFacilities(id);
        }

        public List<Attraction> GetAttractions(int id)
        {
            return _tripRepository.GetAttractions(id);
        }
        
        public Trip Create(NewTripViewModel vm)
        {
            if (DateTime.Parse(vm.StartDate) > DateTime.Parse(vm.EndDate))
                throw new Exception("Ending date must be after starting date!");

            List<Attraction> attrs =_attractionRepository.GetAll();
            List<ItemModel> attrsItems = vm.Attractions.Items.Where(item => item.IsSelected == true).ToList();
            attrs = (from item1 in attrs
                    join item2 in attrsItems on item1.Id equals item2.Id
                         select item1).ToList();
            attrs = attrs.Select(item =>
            {item.Id = 0;
                return item;}).ToList();

            List<TouristFacility> facilities = _facilityRepository.GetAll();
            List<ItemModel> facilityItems = vm.Accomodations.Items.Where(item => item.IsSelected == true).ToList();
            facilityItems.AddRange(vm.Restaurants.Items.Where(item => item.IsSelected == true).ToList());
            facilities = (from item1 in facilities
                         join item2 in facilityItems on item1.Id equals item2.Id
                         select item1).ToList();
            facilities = facilities.Select(item =>
            { item.Id = 0;
                return item;}).ToList();

            return this._tripRepository.Create(vm, attrs, facilities);
        }

        public List<TripListItemViewModel> GetAllReturnListItem()
        {
            return _tripRepository.GetAllReturnListItem();
        }
    }
}
