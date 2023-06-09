using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Repository
{
    public class AttractionRepository : IAttractionRepository
    {
        public List<Attraction> GetAll()
        {
            using (var context = new TravelContext())
            {
                return context.Attractions.ToList();
            }
        }
    }
}
