using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
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
        public ValidationViewModel ValidationViewModel { get; }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); ValidationViewModel.IsNameValid(_name); CheckButtonStatus(); }
        }

        public string Surname
        {
            get => _surname;
            set { _surname = value; OnPropertyChanged(nameof(Surname)); ValidationViewModel.IsSurnameValid(_surname); CheckButtonStatus();
            }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); ValidationViewModel.IsEmailValid(_email); CheckButtonStatus(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); ValidationViewModel.IsPasswordValid(_password, PasswordAgain); CheckButtonStatus(); }
        }

        public string PasswordAgain
        {
            get => _passwordAgain;
            set { _passwordAgain = value; OnPropertyChanged(nameof(PasswordAgain)); ValidationViewModel.IsPasswordAgainValid(_passwordAgain, Password); CheckButtonStatus(); }
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

        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public ICommand Login { get; }
        public ICommand Signup { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CheckButtonStatus()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_surname) || string.IsNullOrWhiteSpace(_email)
                || string.IsNullOrWhiteSpace(_password) || string.IsNullOrWhiteSpace(_passwordAgain))
                IsButtonEnabled = false;
            else
            {
                if (string.IsNullOrWhiteSpace(ValidationViewModel.NameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.SurnameValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.EmailValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.PasswordValidation) &&
                    string.IsNullOrWhiteSpace(ValidationViewModel.PasswordAgainValidation))
                        IsButtonEnabled = true;
                else
                {
                    IsButtonEnabled = false;
                }
            }
        }

        public SignupViewModel()
        {
            Login = new LoginNavigationCommand();
            Signup = new SignupCommand(this);
            ValidationViewModel = new ValidationViewModel();
            IsButtonEnabled = false;
        }
    }
}
