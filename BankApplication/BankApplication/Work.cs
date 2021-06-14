using System;
using System.Collections.Generic;
using BankLibrary;

namespace BankApplication
{
    public abstract class Work
    {
        public static void Start()
        {
            List<ClientAccount> clientList = new List<ClientAccount>();
            bool alive = true;

            while (alive)
            {
                Console.WriteLine("\nВыберите действие:\n" +
                    "1. Создать аккаунт \t 2. Положить деньги \t 3. Снять деньги\n" +
                    "4. Удалить аккаунт \t 5. Информация по аккаунтам \t 6. Выйти из программы");
                try
                {

                    string choise = Console.ReadLine();
                    switch (int.Parse(choise))
                    {
                        case 1:
                            CreatAccount(clientList);
                            break;
                        case 2:
                            Put(clientList);
                            break;
                        case 3:
                            Take(clientList);
                            break;
                        case 4:
                            DeleteAccount(clientList);
                            break;
                        case 5:
                            ShowClients(clientList);
                            break;
                        case 6:
                            alive = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void CreatAccount(List<ClientAccount> clientList)
        {
            Console.WriteLine("\nВведите имя аккаунта:");
            string name = Console.ReadLine();
            ClientAccount client = new ClientAccount(name);
            clientList.Add(client);
        }

        public static void Put(List<ClientAccount> clientList)
        {
            try
            {
                if (clientList.Count == 0)
                {
                    throw new KeyNotFoundException();
                }
                Console.WriteLine("Выберите аккаунт:");
                ShowClients(clientList);
                string selectedAccount = Console.ReadLine();
                Console.WriteLine("Введите вносимую сумму:");
                decimal addedMoney = Convert.ToDecimal(Console.ReadLine());
                clientList[int.Parse(selectedAccount)].Put(addedMoney);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nВведите корректное число!\n");
                Put(clientList);
            }
        }
        public static void Take(List<ClientAccount> clientList)
        {
            try
            {
                if (clientList.Count == 0)
                {
                    throw new KeyNotFoundException();
                }
                Console.WriteLine("Выберите аккаунт:");
                ShowClients(clientList);
                string selectedAccount = Console.ReadLine();
                Console.WriteLine("Введите снимаемую сумму:");
                decimal withdrawnMoney = Convert.ToDecimal(Console.ReadLine());
                clientList[int.Parse(selectedAccount)].Take(withdrawnMoney);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nВведите корректное число!\n");
                Take(clientList);
            }
        }
        public static void ShowClients(List<ClientAccount> clientList)
        {
            foreach (var item in clientList)
            {
                Console.WriteLine($"{item.Id - 1} - {item.Name}, {item.Money}");
            }
        }
        public static void DeleteAccount(List<ClientAccount> clientList)
        {
            Console.WriteLine("Выберите аккаунт, который хотите удалить:");
            ShowClients(clientList);
            string selectedAccount = Console.ReadLine();
            clientList.RemoveAt(int.Parse(selectedAccount));
        }
    }
}
