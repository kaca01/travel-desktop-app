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
                return context.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        public User Create(string name, string surname, string email, string password)
        {
            using (var context = new TravelContext())
            {
                User user = new User() { Name = name, Surname = surname, Email = email, Password = password, Role = Role.CLIENT };
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
        }
    }
}
