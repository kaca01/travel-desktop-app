using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.ViewModel.Component.Agent;

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

        public Trip Create(NewTripViewModel vm)
        {
            if (DateTime.Parse(vm.StartDate) > DateTime.Parse(vm.EndDate))
            {
                throw new Exception("Ending date must be after starting date!");
            }
            return null;
            //return this._tripRepository.Create(vm.Name, vm.Address, vm.Link, type);
        }
    }
}
