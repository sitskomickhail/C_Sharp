using System;
using BankLibrary;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Super_Igor");
            Client clients = new Client();

            int choose = 1;
            while (choose != 0)
            {
                Console.WriteLine("1. Добавить клиента\n2. Показать всех клиентов\n3. Выбрать клиента\n0. Выход");
                try
                {
                    choose = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("Введите число");
                    Console.Clear();
                    continue;
                }
                switch (choose)
                {
                    case 1:
                        clients = Terminal.RegistrationForm();
                        bank.AddClient(clients);
                        Console.Clear();
                        break;
                    case 2:
                        Terminal.ShowAllInfo(bank);
                        break;
                    case 3:
                        if (clients.FirstName == null)
                        {
                            Console.WriteLine("У вас нет пользователей!");
                            break;
                        }
                        int check;
                        while (true)
                        {
                            Terminal.ShowAllInfo(bank);
                            Console.Write("Выберите одного из пользователей: ");
                            try
                            {
                                check = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Введите число");
                                continue;
                            }
                            if (check <= 0 || check > bank.RegisteredCount)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите число еще раз!");
                                continue;
                            }
                            break;
                        }

                        Terminal.ShowClientInfo(bank, check - 1);
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
            Console.Read();
        }
    }
}
