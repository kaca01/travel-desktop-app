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
            List<User> users = context.Users.Where(u => u.Email == email).ToList();
            if (users.Count == 0) return null;
            return users[0];

        }

        private int generateId()
        {
            int max = 0;
            foreach (User u in context.Users)
                if (u.Id > max) max = u.Id;

            return max + 1;
        }
        public User Create(string name, string surname, string email, string password)
        {
            
                User user = new User() { Id = generateId(), Name = name, Surname = surname, Email = email, Password = password, Role = Role.CLIENT };
                context.Users.Add(user);
                return user;
            
        }
    }
}
