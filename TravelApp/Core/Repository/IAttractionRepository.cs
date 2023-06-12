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
        Attraction Create(string name, string address, string description, BitmapImage imageSource);
        public List<Attraction> GetAll();
    }
}
