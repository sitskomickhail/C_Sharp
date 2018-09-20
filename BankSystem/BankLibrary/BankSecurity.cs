using System;

namespace BankLibrary
{
    public static class BankSecurity
    {
        public static bool CheckLogin(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Некорректная информация");
            return true;
        }

        public static bool CheckPass(string value)
        {
            if (value == null)
                throw new ArgumentNullException("Некорректная информация");
            if (value.Length < 4)
                throw new ArgumentOutOfRangeException("Слишком маленький пароль");

            return true;
        }

        public static bool CheckRegistration(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Некорректная информация");
            return true;
        }
    }
}
