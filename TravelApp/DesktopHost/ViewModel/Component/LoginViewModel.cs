using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.Core.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand Signup { get; }

        public LoginViewModel()
        {
            Signup = new SignupNavigationCommand();
        }
    }
}
