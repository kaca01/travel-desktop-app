using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Service
{
    public class TouristFacilityService
    {
        private ITouristFacilityRepository _facilityRepository;

        public TouristFacilityService()
        {
            this._facilityRepository = new TouristFacilityRepository();
        }

        public List<TouristFacilityListItemViewModel> GetTableData()
        {
            return _facilityRepository.Get();
        }
    }
}
