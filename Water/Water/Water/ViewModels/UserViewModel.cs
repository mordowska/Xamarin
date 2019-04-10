using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Water.Validators;
using Water.Models;
using Water.Services;
using Water.Views;

namespace Water.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _name = "";
        private string _email = "";
        private string _phoneNumber = "";
        private string _waterBalance = "";
        private string _consultation = "";

        private string _nameError = "";
        private string _emailError = "";
        private string _phoneNumberError = "";
        private string _waterBalanceError = "";
        private string _consultationError = "";

        public UserViewModel(User user = null)
        {
            _name = user?.Name;
            _email = user?.Email;
            _phoneNumber = user?.PhoneNumber;
            _waterBalance = user?.WaterBalance;
            _consultation = user?.Consultation;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                NameError = !ValidateName() ? "Name can't be empty" : "";
            }
        }

        private bool ValidateName()
        {
            return Validator.EmptyField(Name);
        }

        public string NameError
        {
            get => _nameError;
            set
            {
                _nameError = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                EmailError = !ValidateEmail() ? "Incorrect format of email." : "";
            }
        }

        private bool ValidateEmail()
        {
            return Validator.EmailVal(Email);
        }

        public string EmailError
        {
            get => _emailError;
            set
            {
                _emailError = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
                PhoneError = !ValidatePhone() ? "Incorrect format of phone number." : "";
            }
        }

        private bool ValidatePhone()
        {
            return Validator.PhoneVal(Phone);
        }

        public string PhoneError
        {
            get => _phoneNumberError;
            set
            {
                _phoneNumberError = value;
                OnPropertyChanged();
            }
        }

        public string Water
        {
            get => _waterBalance;
            set
            {
                _waterBalance = value;
                OnPropertyChanged();
                WaterError = !ValidateWater() ? "Incorrect format of water balance." : "";
            }
        }

        private bool ValidateWater()
        {
            return Validator.WaterVal(Water);
        }

        public string WaterError
        {
            get => _waterBalanceError;
            set
            {
                _waterBalanceError = value;
                OnPropertyChanged();
            }
        }

        public string Consultation
        {
            get => _consultation;
            set
            {
                _consultation = value;
                OnPropertyChanged();
                ConsultationError = !ValidateConsultation() ? "Incorrect answer." : "";
            }
        }

        private bool ValidateConsultation()
        {
            return Validator.ConsultationVal(Consultation);
        }

        public string ConsultationError
        {
            get => _consultationError;
            set
            {
                _consultationError = value;
                OnPropertyChanged();
            }
        }


        private bool Validate()
        {
            return ValidateName() && ValidatePhone() && ValidateEmail() && ValidateWater() && ValidateConsultation();
        }


        private void ResetFields()
        {
            Name = "";
            NameError = "";
            Email = "";
            EmailError = "";
            Phone = "";
            PhoneError = "";
            Water = "";
            WaterError = "";
            Consultation = "";
            ConsultationError = "";
        }

        public ICommand NewUserCommand => new Command(AddUser);
        private void AddUser()
        {
            bool valid = Validate();
            if (valid)
            {
                User user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Name,
                    Email = Email,
                    PhoneNumber = Phone,
                    WaterBalance = Water,
                    Consultation = Consultation
                };

                string file = user.Id + ".txt";
                string data = user.Id + "\n" + user.Name + "\n" + user.Email + "\n" + user.PhoneNumber + "\n" + user.WaterBalance + "\n" + user.Consultation;
                DependencyService.Get<IFile>().WriteData(file,data);
                ResetFields();
            }

        }

    }
}