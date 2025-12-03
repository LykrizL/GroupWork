// Балакин Новая Функция
        public bool IsValidPassword(string password) // Функция проверки пароля
        {
            string passwordPattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }
