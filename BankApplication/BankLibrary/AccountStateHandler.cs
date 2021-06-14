using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public decimal Money { get; private set; }
        public AccountEventArgs(string Message, decimal Money)
        {
            this.Message = Message;
            this.Money = Money;
        }
    }
}
