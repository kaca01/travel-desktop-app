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
    public class TravelContext : DbContext
    {

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TravelDb");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TouristFacility> TouristFacilities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
