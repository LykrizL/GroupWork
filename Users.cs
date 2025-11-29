using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkLibrary
{
    public class Users : People
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
        public bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }
        public bool IsPasswordСonfirm(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }
        public bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool IsValidPhone(string phone)
        {
            string phonePattern = @"^\+7\d{10}$";
            return Regex.IsMatch(phone, phonePattern);
        }
        public bool IsValidFullName(string fullName)
        {
            string fullNamePattern = @"^([А-ЯЁ][а-яё]+)\s([А-ЯЁ][а-яё]+)\s([А-ЯЁ][а-яё]+)$";
            return Regex.IsMatch(fullName, fullNamePattern);
        }
        public bool IsValidLogin(string Login)
        {
            string loginPattern = @"^[a-zA-Z][a-zA-Z0-9]{6,}$";
            return Regex.IsMatch(Login, loginPattern);
        }
        public override string GetInfo()
        {
            return ($"{UserLogin},{FullName},{Email},{Phone},{UserPassword}");
        }
        public void IsFileWrite(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true для добавления
            {
                writer.WriteLine(GetInfo());
            }
        }
        public void IsFileWriteOnce(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(GetInfo());
            }
        }
        public static void IsReadFile(List<Users> data, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 5) // Ожидаем 5 частей (логин, ФИО, email, телефон, пароль)
                {
                    string userLogin = parts[0]; // Извлекаем логин
                    string userFullName = parts[1]; // Извлекаем ФИО
                    string userEmail = parts[2]; // Извлекаем email
                    string userPhone = parts[3]; // Извлекаем телефон
                    string userPassword = parts[4]; // Извлекаем пароль

                    data.Add(new Users(userLogin, userFullName, userEmail, userPhone, userPassword));
                }
            }
        }
    }
}
