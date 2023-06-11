using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;

namespace TravelApp.Core.Service
{
    public class AttractionService : IAttractionService
    {
        private IAttractionRepository _repository;


        public AttractionService()
        {
            _repository = new AttractionRepository();
        }

        public List<Attraction> GetAll()
        {
            return _repository.GetAll();
        }

        public Attraction Get(int id)
        {
            return _repository.Get(id);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
