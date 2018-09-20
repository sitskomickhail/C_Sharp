using System;

namespace BankLibrary
{
    public class Bank
    {
        #region FIELDS
        private string _name;
        private Client[] _clients;
        private const int MAX_COUNT_CLIENTS = 10;
        private const double COMISS = 1.5;
        private static int CLIENT_COUNT;
        #endregion


        #region METHODS

        public Bank(string name)
        {
            Name = name;
            _clients = new Client[MAX_COUNT_CLIENTS];
        }
        public void AddClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("client is null");

            for (int i = 0; i < CLIENT_COUNT; i++)
            {
                if (client.Pasport == _clients[i].Pasport)
                {
                    _clients[i].AddAccount();
                    _clients[i].UserChoose = 0;

                    string pass = _clients[i].Password;
                    string login = _clients[i].Login;
                    string fname = _clients[i].FirstName;
                    string lname = _clients[i].LastName; 

                    _clients[i].UserChoose = 1;
                    _clients[i].Password = pass;
                    _clients[i].Login = login;
                    _clients[i].FirstName = fname;
                    _clients[i].LastName = lname;
                    return;
                }
            }

            _clients[CLIENT_COUNT] = client;
            CLIENT_COUNT++;
        }
        #endregion


        #region PRTIES
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name is not correct...");
                _name = value;
            }
        }

        public Client[] GetAllClients
        { get { return _clients; } }

        public int RegisteredCount
        { get { return CLIENT_COUNT; } }

        public static double ComissionPercent
        { get { return COMISS; } }
        #endregion
    }
}
