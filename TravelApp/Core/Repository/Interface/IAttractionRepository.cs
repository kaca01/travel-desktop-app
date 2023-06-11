using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Repository
{
    public interface IAttractionRepository
    {
        public List<Attraction> GetAll();

        public Attraction Get(int id);

        public bool Delete(int id);
    }
}
