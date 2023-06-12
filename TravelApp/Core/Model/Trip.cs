using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TravelApp.Core.Model
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<TouristFacility> FacilityList { get; set;} = new List<TouristFacility>();
        public virtual List<Attraction> Attractions { get; set;} = new List<Attraction>();
        public BitmapImage Picture { get; set; }
    }
}
