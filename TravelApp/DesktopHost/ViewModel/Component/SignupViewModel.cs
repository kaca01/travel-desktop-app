using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.Core.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class SignupViewModel : BaseViewModel
    {
        public ICommand Login { get; }

        public SignupViewModel()
        {
            Login = new LoginNavigationCommand();
        }
    }
}
