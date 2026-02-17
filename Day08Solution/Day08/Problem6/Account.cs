using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem6
{
    internal struct Account
    {
        private int accountId;
        private string accountHolder;
        private double balance;

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public double Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Balance cant be negative");
            }
        }

        public Account(int id, string holder, double balance)
        {
            accountId = id;
            accountHolder = holder;
            this.balance = 0;
            Balance = balance; // to use property for validation
        }

        public override string ToString()
        {
            return $"AccountId: {accountId}, AccountHolder: {accountHolder}, Balance: {Math.Round(balance,2)}";
        }
    }
}
