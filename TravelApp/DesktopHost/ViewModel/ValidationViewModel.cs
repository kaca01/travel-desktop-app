using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelApp.DesktopHost.Command;

namespace TravelApp.DesktopHost.ViewModel
{
    public class ValidationViewModel : BaseViewModel
    {
        private string _nameValidation;
        private string _surnameValidation;
        private string _emailValidation;
        private string _passwordValidation;
        private string _passwordAgainValidation;

        private string _addressValidation;
        private string _linkValidation;

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

        public string AddressValidation
        {
            get => _addressValidation;
            set { _addressValidation = value; OnPropertyChanged(nameof(AddressValidation)); }
        }

        public string LinkValidation
        {
            get => _linkValidation;
            set { _linkValidation = value; OnPropertyChanged(nameof(LinkValidation)); }
        }

        public void ValidateAll(Validation user)
        {
            IsNameValid(user.Name);
            IsSurnameValid(user.Surname);
            IsEmailValid(user.Email);
            IsPasswordValid(user.Password, user.PasswordAgain);
            IsPasswordAgainValid(user.PasswordAgain, user.Password);
        }

        public Validation GetValidationMessages()
        {

            return new Validation(NameValidation, SurnameValidation, EmailValidation, 
                PasswordValidation, PasswordAgainValidation);
        }

        public bool IsNameValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) NameValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) NameValidation = "Required";
            else if (name.Trim().Length < 3) NameValidation = "Name must contain minimum 3 characters";
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
            else if (name.Trim().Length < 3) SurnameValidation = "Surname must contain minimum 3 characters";
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
                Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
                Match match = regex.Match(name);
                if (!match.Success) { 
                    EmailValidation = "Format not valid";
                    return false;
                }
                EmailValidation = "";
                return true;
            }
            return false;
        }

        public static bool IsAnyPasswordValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            else if (string.IsNullOrWhiteSpace(name.Trim())) return false;
            else if (name.Trim().Length < 8) return false;
            {
                return true;
            }
        }

        public bool IsPasswordValid(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name)) PasswordValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) PasswordValidation = "Required";
            else if (name.Trim().Length < 8) PasswordValidation = "Password must contain minimum 8 characters";
            else
            {
                PasswordValidation = "";
                if (name.Equals(password)) { 
                    PasswordAgainValidation = "";
                    return true;
                }
                else
                {
                    PasswordAgainValidation = "Passwords aren't matching!";
                    return false;
                }
            }
            return false;
        }


        public bool IsPasswordAgainValid(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name)) PasswordAgainValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) PasswordAgainValidation = "Required";
            else if (name.Trim().Length < 8) PasswordAgainValidation = "Password must contain minimum 8 characters";
            else if (!name.Equals(password)) PasswordAgainValidation = "Passwords aren't matching!";
            else
            {
                PasswordAgainValidation = "";
                return true;
            }
            return false;
        }

        public bool IsAddressValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) AddressValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) AddressValidation = "Required";
            else if (name.Trim().Length < 3) AddressValidation = "Address must contain minimum 3 characters";
            else
            {
                AddressValidation = "";
                return true;
            }
            return false;
        }

        public bool IsLinkValid(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) LinkValidation = "Required";
            else if (string.IsNullOrWhiteSpace(name.Trim())) LinkValidation = "Required";
            else
            {
                Regex regex = new Regex("^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
                Match match = regex.Match(name);
                if (!match.Success)
                {
                    LinkValidation = "Format not valid";
                    return false;
                }
                LinkValidation = "";
                return true;
            }
            return false;
        }

    }


    public class Validation
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }

        public Validation(string name, string surname, string email, string password, string pa)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            PasswordAgain = pa;
        }
    }
}
