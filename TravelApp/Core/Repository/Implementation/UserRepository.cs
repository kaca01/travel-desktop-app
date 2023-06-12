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
        TravelContext context = TravelContext.Instance;
        public List<User> GetAll()
        {
                return context.Users.ToList();
           
        }

        public User GetById(int id)
        {
                return context.Users.Where(u => u.Id == id).ToList()[0];

        }

        public User GetByEmail(string email)
        {
                return context.Users.Where(u => u.Email == email).ToList()[0];

        }

        public User Create(string name, string surname, string email, string password)
        {
            
                User user = new User() { Name = name, Surname = surname, Email = email, Password = password, Role = Role.CLIENT };
                context.Users.Add(user);
                return user;
            
        }
    }
}
