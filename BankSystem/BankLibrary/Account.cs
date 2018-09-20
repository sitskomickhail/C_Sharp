using System;

namespace BankLibrary
{
    public class Account
    {
        #region FILEDS
        private string _login;
        private string _password;
        private readonly string _serialNumber;
        private double _cash;
        #endregion

        #region CTOR
        public Account()
        {
            _serialNumber = Randomer.Next(10);
            _cash = 100;
        }
        #endregion

        #region METHODS
        public void GetMoney(double count)
        {
            if (count > _cash)
                throw new ArgumentOutOfRangeException("Слишком большое передаваемое число");
            if (count < 0)
                throw new ArgumentOutOfRangeException("Слишком маленькое передаваемое число");
            _cash -= count + (count * Bank.ComissionPercent / 100);
        }

        public void SetMoney(double count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("Слишком маленькое передаваемое число");
            _cash += count;
        }
        #endregion

        #region PRTIES
        public string Login
        {
            get { return _login; }
            set
            {
                if (BankSecurity.CheckLogin(value))
                    _login = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (BankSecurity.CheckPass(value))
                    _password = value;
            }
        }

        public string AccountNumber
        {
            get { return _serialNumber; }
        }

        public double Money
        { get { return _cash; } }

        #endregion
    }
}
