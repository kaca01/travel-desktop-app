using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel;

namespace TravelApp.Core.Service
{
    internal class TripService : ITripService
    {
        private ITripRepository _tripRepository;

        public TripService()
        {
            _tripRepository = new TripRepository();
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

        public List<TripListItemViewModel> GetAllReturnListItem()
        {
            return _tripRepository.GetAllReturnListItem();
        }
    }
}
