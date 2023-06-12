using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;

namespace TravelApp.Core.Repository
{
    public class AttractionRepository : IAttractionRepository
    {
        TravelContext context = TravelContext.Instance;
        public List<Attraction> GetAll()
        {

                return context.Attractions.Where(a => !a.IsDeleted).ToList();

        }

        public Attraction Get(int id)
        {
                return context.Attractions.Where(u => u.Id == id).ToList()[0];

        }

        public bool Delete(int id)
        {
                Attraction attraction = context.Attractions.Where(u => u.Id == id).ToList()[0];
            if (attraction != null)
                {
                    attraction.IsDeleted = true;
                    //todo check if this works
                    return true;
                }
                return false;
        }

        public Attraction Create(string name, string address, string description, BitmapImage imageSource)
        {
                Attraction a = new Attraction() { Name = name, Description = description, Address = address, Image = ImageConverter.ConvertImageSourceToByteArray(imageSource) };
                context.Attractions.Add(a);
                return a;
        }
    }
}
