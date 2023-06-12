using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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
