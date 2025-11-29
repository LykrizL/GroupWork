using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Новые внесенные изменения в код
namespace WorkLibrary // Название пространства
{
    public class Users : People // Название класса
    {
        private string _userLogin;
        private string _userPassword;
        public Users(string Login, string FullName, string Email, string Phone,  string Password):base(FullName, Phone, Email)
        {
            _userLogin = Login;
            _userPassword = Password;
        }
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
            }
        }
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
            }
        }
        public bool IsValidPassword(string password) // Функция проверки пароля
        {
            string passwordPattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }
        public bool IsPasswordСonfirm(string password, string confirmPassword) // Функция принятия пароля
        {
            return password == confirmPassword;
        }
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool IsValidPhone(string phone) // Функция проверки номера телефона
        {
            string phonePattern = @"^\+7\d{10}$";
            return Regex.IsMatch(phone, phonePattern);
        }
        public bool IsValidFullName(string fullName)
        {
            string fullNamePattern = @"^([А-ЯЁ][а-яё]+)\s([А-ЯЁ][а-яё]+)\s([А-ЯЁ][а-яё]+)$";
            return Regex.IsMatch(fullName, fullNamePattern);
        }
        public override string GetInfo()
        {
            return ($"{UserLogin},{FullName},{Email},{Phone},{UserPassword}");
        }

        public void IsFileWriteOnce(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(GetInfo());
            }
        }
  
    }
}
