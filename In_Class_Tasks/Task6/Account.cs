using System;

namespace Task6
{
    public class Account
    {
        public int Number { get; set; }
        public string Owner { get; set; }
        public double Balance { get; set; }

        public Account()
        {
            Number = 0;
            Owner = "Unknown";
            Balance = 0;
        }

        public Account(int number, string owner)
        {
            Number = number;
            Owner = owner;
            Balance = Balance;
        }

        public Account(int number, string owner, double balance)
        {
            Number = number;
            Owner = owner;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance) Balance -= amount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account {Number}, {Owner}, Balance: {Balance}");
        }
    }
}

