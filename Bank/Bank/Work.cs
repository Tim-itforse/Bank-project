using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    abstract class Work
    {
        public static void Start()
        {
            try
            {
                Dictionary<int, ClientAccount> clientList = new Dictionary<int, ClientAccount>();
                int count = 0;
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
                                CreatAccount(clientList, ref count);
                                break;
                            case 2:
                                PutMoney(clientList);
                                break;
                            case 3:
                                TakeMoney(clientList);
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
                    catch (FormatException)
                    {
                        Console.WriteLine("\nВведите корректное число!\n");
                        PutMoney(clientList);
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("\nАккаунты, с которыми можно провести эту операцию, не существуют!\n");
                    }
                }
            }
            catch
            {
                Start();
            }
        }
        public static void CreatAccount(Dictionary<int, ClientAccount> clientList, ref int count)
        {
            Console.WriteLine("\nВведите имя аккаунта:");
            string name = Console.ReadLine();
            ClientAccount client = new ClientAccount(name);
            clientList.Add(count++, client);
        }
        public static void PutMoney(Dictionary<int, ClientAccount> clientList)
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
                PutMoney(clientList);
            }

        }
        public static void TakeMoney(Dictionary<int, ClientAccount> clientList)
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
                TakeMoney(clientList);
            }
        }
        public static void ShowClients(Dictionary<int, ClientAccount> clientList)
        {            
            foreach (var item in clientList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name}, {item.Value.Money}");
            }
        }
        public static void DeleteAccount(Dictionary<int, ClientAccount> clientList)
        {
            Console.WriteLine("Выберите аккаунт, который хотите удалить:");
            ShowClients(clientList);
            string selectedAccount = Console.ReadLine();
            clientList.Remove(int.Parse(selectedAccount));
        }
    }
}
