using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TravelApp.Core.Model;

namespace TravelApp.Core.Repository
{
    public interface IAttractionRepository
    {
        public List<Attraction> GetAll();

        public Attraction Get(int id);

        public bool Delete(int id);

        Attraction Create(string name, string address, string description, BitmapImage imageSource);
    }
}
