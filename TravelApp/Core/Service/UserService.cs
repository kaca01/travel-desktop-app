using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.Command;
using TravelApp.DesktopHost.ViewModel.Navigation;

namespace TravelApp.Core.Service
{
    public class UserService
    {
        private IUserRepository userRepository;
        public static User CurrentUser { get; set; }

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public void Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) | string.IsNullOrEmpty(password))
                throw new Exception("All fields must be filled !");

            User foundUser = this.userRepository.GetByEmail(email);
            if (foundUser == null) throw new Exception("Wrong credentials !");
            if (!foundUser.Password.Equals(password)) throw new Exception("Wrong credentials !");

            CurrentUser = foundUser;
        }

    }
}
