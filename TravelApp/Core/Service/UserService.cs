using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Model;
using TravelApp.Core.Repository;
using TravelApp.DesktopHost.Command;
using TravelApp.DesktopHost.ViewModel;
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

            email = email.Trim();
            password = password.Trim();
            if (string.IsNullOrEmpty(email) | string.IsNullOrEmpty(password))
                throw new Exception("All fields must be filled !");

            User foundUser = this.userRepository.GetByEmail(email);
            if (foundUser == null) throw new Exception("Wrong credentials !");
            if (!foundUser.Password.Equals(password)) throw new Exception("Wrong credentials !");

            CurrentUser = foundUser;
        }

        public void Signup(Validation user, SignupViewModel vm)
        {   
            vm.ValidationViewModel.ValidateAll(user);
            Validation validation = vm.ValidationViewModel.GetValidationMessages();
            if (string.IsNullOrEmpty(validation.Name) & string.IsNullOrEmpty(validation.Surname) &
                string.IsNullOrEmpty(validation.Email) &string.IsNullOrEmpty(validation.Password) &
                    string.IsNullOrEmpty(validation.PasswordAgain))
            {
                if (this.userRepository.GetByEmail(user.Email) != null) throw new Exception("User with this email already exists!");
                this.userRepository.Create(user.Name, user.Surname, user.Email, user.Password);
            }
            else
            {
                throw new Exception("Invalid data!");
            }
        }

    }
}
