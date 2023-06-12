using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core
{
    public class TravelContext
    {
        private TravelContext() { }

        private static TravelContext instance = null;
        public static TravelContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TravelContext();
                }
                return instance;
            }
        }

        public List<User> Users { get; set; } = new List<User>();
        public List<TouristFacility> TouristFacilities { get; set; } = new List<TouristFacility>();
        public List<Attraction> Attractions { get; set; } = new List<Attraction>();
        public List<Trip> Trips { get; set; } = new List<Trip>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
