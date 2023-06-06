using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;

namespace TravelApp.Core.Repository
{
    public  interface IUserRepository
    {
        public List<User> GetAll();

        public User GetById(int id);

        public User GetByEmail(string email);

        public User Create(string name, string surname, string email, string password);
    }
}
