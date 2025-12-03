 public bool IsValidPhone(string phone) 
 {
            string phonePattern = @"^\+7\d{10}$";
            return Regex.IsMatch(phone, phonePattern);
 }

