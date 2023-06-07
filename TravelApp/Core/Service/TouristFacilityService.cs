﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;

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

        public TouristFacility Create(string name, string address, PlaceType placeType, string link)
        {
            //todo call validation
            return null;
        }
    }
}
