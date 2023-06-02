using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Core.Repository;

namespace TravelApp.Core.Service
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        //todo add methods
    }
}
