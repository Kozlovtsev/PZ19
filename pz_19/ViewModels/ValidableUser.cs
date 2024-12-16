using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.ViewModels
{
    public class ValidableUser : ValidableBindableBase
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _fullName;
        [Required(ErrorMessage = "Полное имя является обязательным")]
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        private string _phoneNumber;
        [Phone(ErrorMessage = "Неверный формат номера телефона")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private string _login;
        [Required(ErrorMessage = "Логин является обязательным")]
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        [Required(ErrorMessage = "Пароль является обязательным")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private int _specialistId;
        public int SpecialistId
        {
            get => _specialistId;
            set => SetProperty(ref _specialistId, value);
        }

        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            set => SetProperty(ref _clientId, value);
        }
    }
}
