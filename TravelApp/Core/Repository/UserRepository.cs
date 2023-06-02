using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        
        public List<User> GetAll()
        {
            using (var context = new TravelContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetById(int id)
        {
            using (var context = new TravelContext())
            {
                return context.Users.First(u => u.Id == id);
            }
        }

        public User GetByEmail(string email)
        {
            using (var context = new TravelContext())
            {
                return context.Users.First(u => u.Email == email);
            }
        }
    }
}
