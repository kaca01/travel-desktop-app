using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ValidationViewModel : BaseViewModel
    {
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

        public bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) NameValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) NameValidation = "Required";
            else
            {
                NameValidation = "";
                return true;
            }
            return false;
        }

        public bool IsSurnameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) SurnameValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) SurnameValidation = "Required";
            else
            {
                SurnameValidation = "";
                return true;
            }
            return false;
        }


        public bool IsEmailValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) EmailValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) EmailValidation = "Required";
            else
            {
                EmailValidation = "";
                return true;
            }
            return false;
        }

        public bool IsAnyPasswordValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            else if (string.IsNullOrWhiteSpace(name.Trim())) return false;
            else
            {
                return true;
            }
            return false;
            //todo add check for min characters
        }

        public bool IsPasswordValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) PasswordValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) PasswordValidation = "Required";
            else
            {
                PasswordValidation = "";
                return true;
            }
            return false;
            //todo add check for min characters
        }


        public bool IsPasswordAgainValid(string name, string passwordAgain)
        {
            if (string.IsNullOrWhiteSpace(name)) PasswordAgainValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) PasswordAgainValidation = "Required";
            else
            {
                PasswordAgainValidation = "";
                return true;
            }
            return false;
            //todo add check for min characters and compare passwords
        }
    }
}
