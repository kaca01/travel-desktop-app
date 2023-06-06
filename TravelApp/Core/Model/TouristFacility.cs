using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Core.Model
{
    public enum PlaceType
    {
        ACCOMODATION, RESTAURANT
    }

    public class TouristFacility
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public PlaceType Type { get; set; }
        public string Link { get; set; }

        public bool IsDeleted { get; set; }
    }
}
