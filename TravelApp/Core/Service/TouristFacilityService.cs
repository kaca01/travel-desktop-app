using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

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
            vm.ValidationViewModel.ValidateNewPlace(vm.Name, vm.Address, vm.Link);
            Validation validation = vm.ValidationViewModel.GetSignupValidationMessages();
            if (string.IsNullOrEmpty(validation.Name) & string.IsNullOrEmpty(validation.Surname) &
                string.IsNullOrEmpty(validation.Email))
            {
                PlaceType type = PlaceType.RESTAURANT;
                if (vm.Accomodation) type = PlaceType.ACCOMODATION;
                return this._facilityRepository.Create(vm.Name, vm.Address, vm.Link, type);
            }
            else
            {
                throw new Exception("Invalid data!");
            }
        }
    }
}
