using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;
using TravelApp.DesktopHost.ViewModel.ItemViewModel;

namespace TravelApp.Core.Service
{
    public class TouristFacilityService
    {
        private ITouristFacilityRepository _facilityRepository;

        public ITouristFacilityRepository FacilityRepository { get { return _facilityRepository; } }

        public TouristFacilityService()
        {
            this._facilityRepository = new TouristFacilityRepository();
        }

        public List<TouristFacilityListItemViewModel> GetTableData()
        {
            return _facilityRepository.Get();
        }

        public TouristFacility Create(NewPlaceViewModel vm)
        {
            PlaceType type = PlaceType.RESTAURANT;
            if (vm.Accomodation) type = PlaceType.ACCOMODATION;
            return this._facilityRepository.Create(vm.Name, vm.Address, vm.Link, type);
        }

        public List<ItemModel> GetRestaurantsItemModel()
        {
            List<TouristFacility> tf = this._facilityRepository.GetValidRestaurants();
            return tf.Select(a => new ItemModel
            {
                Name = a.Name,
                IsSelected = false
            }).ToList();
        }

        public List<ItemModel> GetAccomodationsItemModel()
        {
            List<TouristFacility> tf = this._facilityRepository.GetValidAccomodations();
            return tf.Select(a => new ItemModel
            {
                Name = a.Name,
                IsSelected = false
            }).ToList();
        }
    }
}
