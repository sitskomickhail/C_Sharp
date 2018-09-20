using System;

namespace BankLibrary
{
    public class Client
    {
        #region FIELDS
        private string _lastName;
        private string _firstName;
        private string _numPasport;
        private int _userChoose;
        private int _accountCount;
        private Account[] _account;
        #endregion

        #region CTOR
        public Client()
        {
            _accountCount = 1;
            _account = new Account[2];
            _account[_userChoose] = new Account();
        }
        #endregion

        #region METHODS
        public void AddAccount()
        {
            if (_accountCount >= 2)
                throw new ArgumentOutOfRangeException("Максимум можно создать только 2 лицевых счета");
            _accountCount++;
            _userChoose = 1;
            _account[_userChoose] = new Account();
        }

        public void GetMoney(double count)
        {
            _account[_userChoose].GetMoney(count);
        }

        public void SetMoney(double count)
        {
            _account[_userChoose].SetMoney(count);
        }
        #endregion

        #region PRTIES
        public string LastName
        {
            get { return _lastName; }
            set { if (BankSecurity.CheckRegistration(value)) _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            { if (BankSecurity.CheckRegistration(value)) _firstName = value; }
        }

        public string Pasport
        {
            get { return _numPasport; }
            set
            { if (BankSecurity.CheckRegistration(value)) _numPasport = value; }
        }

        public int UserChoose
        {
            set
            {
                if (value > 1 || value < 0)
                    throw new ArgumentOutOfRangeException("Выход за переделы допустимых аргументов");
                _userChoose = value;
            }
        }

        public int AccountCount
        { get { return _accountCount; } }

        public string Login
        {
            get { return _account[_userChoose].Login; }
            set { _account[_userChoose].Login = value; }
        }

        public string Password
        {
            get { return _account[_userChoose].Password; }
            set { _account[_userChoose].Password = value; }
        }

        public string AccountNumber
        { get { return _account[_userChoose].AccountNumber; } }

        public double Money
        { get { return _account[_userChoose].Money; } }

        #endregion
    }
}