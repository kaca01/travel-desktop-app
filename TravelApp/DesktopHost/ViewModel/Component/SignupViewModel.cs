using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelApp.DesktopHost.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class SignupViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _password;
        private string _passwordAgain;

        private string _nameValidation;
        private string _surnameValidation;
        private string _emailValidation;
        private string _passwordValidation;
        private string _passwordAgainValidation;

        public string NameValidation
        {
            get => _nameValidation;
            set { _nameValidation = value; OnPropertyChanged(nameof(NameValidation)); }
        }

        public string SurnameValidation
        {
            get => _surnameValidation;
            set { _surnameValidation = value; OnPropertyChanged(nameof(SurnameValidation)); }
        }

        public string EmailValidation
        {
            get => _emailValidation;
            set { _emailValidation = value; OnPropertyChanged(nameof(EmailValidation)); }
        }

        public string PasswordValidation
        {
            get => _passwordValidation;
            set { _passwordValidation = value; OnPropertyChanged(nameof(PasswordValidation)); }
        }

        public string PasswordAgainValidation
        {
            get => _passwordAgainValidation;
            set { _passwordAgainValidation = value; OnPropertyChanged(nameof(PasswordAgainValidation)); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Surname
        {
            get => _surname;
            set { _surname = value; OnPropertyChanged(nameof(Surname));
            }
        }

        public string Email
        {
            get => _email;
            set { _email = value; 
                EmailValidation = "Required";
                //todo call validation function
                OnPropertyChanged(nameof(Email)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string PasswordAgain
        {
            get => _passwordAgain;
            set { _passwordAgain = value; OnPropertyChanged(nameof(PasswordAgain)); }
        }

        private double _textFontSize;
        private double _loginFontSize;

        private double _width;
        public double TextFontSize
        {
            get { return _textFontSize; }
            set
            {
                if (_textFontSize != value)
                {
                    _textFontSize = value;
                    OnPropertyChanged(nameof(TextFontSize));
                }
            }
        }

        public double LoginFontSize
        {
            get { return _loginFontSize; }
            set
            {
                if (_loginFontSize != value)
                {
                    _loginFontSize = value;
                    OnPropertyChanged(nameof(LoginFontSize));
                }
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }
        public ICommand Login { get; }
        public ICommand Signup { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SignupViewModel()
        {
            Login = new LoginNavigationCommand();
            Signup = new SignupCommand(this);
            SnackbarMessageQueue = new SnackbarMessageQueue();
        }
    }
}
