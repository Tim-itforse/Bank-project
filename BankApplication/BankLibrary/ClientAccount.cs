using System;

namespace BankLibrary
{
    public class ClientAccount : Account
    {
        public string Name { get; private set; }
        public ClientAccount(string Name) : base()
        {
            this.Name = Name;
        }
    }
}
