using System;

namespace Bank
{
    class ClientAccount
    {
        public string Name{ get; }
        public decimal Money { get; private set; }
        public ClientAccount(string Name)
        {
            this.Name = Name;
            Money = 0;
        }
        public void Put(decimal Money)
        {
            this.Money += Money;
        }
        public void Take(decimal Money)
        {
            if (this.Money >= Money)
            {
                this.Money -= Money;
            }
            else
            {
                Console.WriteLine("\nНедостаточно средств!\n");
            }
        }
    }
}
