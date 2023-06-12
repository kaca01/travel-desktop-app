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
        public List<Attraction> GetAll()
        {
            using (var context = new TravelContext())
            {
                return context.Attractions.Where(a => !a.IsDeleted).ToList();
            }
        }

        public Attraction Get(int id)
        {
            using (var context = new TravelContext())
            {
                return context.Attractions.First(t => t.Id == id);
            }
        }

        public bool Delete(int id)
        {
            using (var context = new TravelContext())
            {
                Attraction attraction = context.Attractions.First(t => t.Id == id);
                if (attraction != null)
                {
                    attraction.IsDeleted = true;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Attraction Create(string name, string address, string description, BitmapImage imageSource)
        {
            using (var context = new TravelContext())
            {

                Attraction a = new Attraction() { Name = name, Description = description, Address = address, Image = ImageConverter.ConvertImageSourceToByteArray(imageSource) };
                context.Attractions.Add(a);
                context.SaveChanges();
                return a;
            }
        }
    }
}
