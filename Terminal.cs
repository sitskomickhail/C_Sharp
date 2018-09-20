using System;
using BankLibrary;

namespace BankSystem
{
    public static class Terminal
    {
        public static Client RegistrationForm()
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите номер паспорта: ");
            string numPasport = Console.ReadLine();

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            return new Client() { FirstName = firstName, LastName = lastName, Pasport = numPasport, Login = login, Password = password };
        }

        public static void ShowClientInfo(Bank bank, int position)
        {
            Client[] clients = bank.GetAllClients;
            Client client = clients[position];

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите логин:   ");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль:  ");
                string password = Console.ReadLine();

                if (login != client.Login || password != client.Password)
                {
                    Console.Clear();
                    Console.WriteLine("Неверный логин или пароль!");
                    if (i == 2)
                    {
                        Console.WriteLine("Вы исчерпали все попытки ввода логина или пароля");
                        Console.Read();
                        Environment.Exit(0);
                    }
                    Console.WriteLine("У вас осталось {0} попыток", 2 - i);
                }
                else
                    break;
            }
            Console.Clear();
            int check;

            if (client.AccountCount > 1)
            {
                client.UserChoose = 0;
                Console.WriteLine("Выберите лицевой счет:\n1 - {0}", client.AccountNumber);
                client.UserChoose = 1;
                Console.WriteLine("2 - {0}", client.AccountNumber);
                while (true)
                {
                    try
                    {
                        check = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Введите число еще раз!");
                        continue;
                    }
                    if (check <= 0 || check > 2)
                    {
                        Console.WriteLine("Введите число еще раз!");
                        continue;
                    }
                    break;
                }
                client.UserChoose = check - 1;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Имя:     {0}\nФамилия:        {1}\nНомер паспорта:     {2}\nНомер счета:        {3}", client.FirstName, client.LastName,
                                                                                                                         client.Pasport, client.AccountNumber);
                Console.WriteLine("Выберите действие:\n1 - Просмотреть баланс\n2 - Снять деньги со счета\n3 - Положить деньги на счет\n0 - Выход в главное меню");
                while (true)
                {
                    try
                    {
                        check = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Введите число еще раз!");
                        continue;
                    }
                    if (check < 0 || check > 3)
                    {
                        Console.WriteLine("Введите число еще раз!");
                        continue;
                    }
                    break;
                }
                Console.WriteLine();
                switch (check)
                {
                    case 1:
                        Console.WriteLine("Остаток на счету : {0}", client.Money);
                        break;
                    case 2:
                        double _bank_cashback;
                        Console.Write("Введите сколько денег вы хотите снять: ", client.Money);
                        try
                        {
                            _bank_cashback = Double.Parse(Console.ReadLine());
                            client.GetMoney(_bank_cashback);
                        }
                        catch (Exception exep)
                        {
                            Console.Clear();
                            Console.WriteLine(exep.Message);
                            return;
                        }
                        Console.WriteLine("С вашего счета снято : {0}", _bank_cashback + _bank_cashback * Bank.ComissionPercent / 100);
                        break;
                    case 3:
                        Console.Write("Введите сколько денег вы хотите положить: ");
                        try
                        {
                            client.GetMoney(Double.Parse(Console.ReadLine()));
                        }
                        catch (Exception exep)
                        {
                            Console.Clear();
                            Console.WriteLine(exep.Message);
                            return;
                        }
                        Console.WriteLine("Теперь на вашем балансе - {0}", client.Money);
                        break;
                    case 0:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
                Console.WriteLine("1 - Выйти в главное меню\n2 - Вернуться к действию со счетом");
                if (!Continue__())
                    break;
            }
            Console.Clear();
        }

        public static void ShowAllInfo(Bank bank)
        {
            Client[] clients = bank.GetAllClients;
            Console.WriteLine("  Имя      Фамилия      Номер паспорта       Лицевой счет");
            for (int i = 0; i < bank.RegisteredCount; i++)
            {
                if (clients[i].AccountCount > 1)
                {
                    Console.Write(i + 1);
                    clients[i].UserChoose = 0;
                    Console.WriteLine("  {0}      {1}      {2}           {3}", clients[i].FirstName, clients[i].LastName, clients[i].Pasport, clients[i].AccountNumber);
                    clients[i].UserChoose = 1;
                }
                Console.Write(i + 1);
                Console.WriteLine("  {0}      {1}      {2}           {3}", clients[i].FirstName, clients[i].LastName, clients[i].Pasport, clients[i].AccountNumber);
            }
            Console.WriteLine("______________________________________________________________");
        }

        private static bool Continue__()
        {
            while (true)
            {
                int _choose;
                try
                {
                    _choose = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число еще раз!");
                    continue;
                }
                if (_choose < 1 || _choose > 2)
                {
                    Console.WriteLine("Введите число еще раз!");
                    continue;
                }

                if (_choose == 1)
                    return false;
                else
                    return true;
            }
        }
    }
}