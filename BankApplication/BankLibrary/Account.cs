using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Added;
        static int counter = 0;

        public decimal Money { get; private set; }
        public int Id { get; private set; }
        public Account()
        {
            Money = 0;
            Id = ++counter;
        }
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null)
            {
                handler?.Invoke(this, e);
            }
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }
        public virtual void Put(decimal Money)
        {
            this.Money = Money;
            OnAdded(new AccountEventArgs("На счет поступило: " + Money, Money));
        }

        public virtual decimal Take(decimal Money)
        {
            decimal result = 0;
            if (this.Money >= Money)
            {
                this.Money -= Money;
                result = Money;
                OnWithdrawed(new AccountEventArgs($"Сумма {Money} снята со счета {Id}", Money));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs($"Недостаточно средств на счете {Id}", 0));
            }
            return result;
        }
    }
}
