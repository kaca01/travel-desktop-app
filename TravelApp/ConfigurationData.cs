using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core;
using TravelApp.Core.Model;

namespace TravelApp
{
    public class ConfigurationData
    {
        public void PopulateDataBase()
        {
            using (var db = new TravelContext())
            {
                // todo add data

                User client = new User() { Name = "Roberto", Surname = "Bolano", Email = "roberto@gmail.com", Password = "pass1234", Role = Role.CLIENT };
                User agent = new User() { Name = "Mario", Surname = "Giordani", Email = "mario@gmail.com", Password = "pass1234", Role = Role.AGENT };
                db.Users.Add(client);
                db.Users.Add(agent);
                db.SaveChanges();
            }
        }
    }
}
