using System;

namespace Exam2_Review_Codes
{
    public class Account
    {
        public int id;
        public string type;
        public Customer customer;
        public double balance;
        public DateTime openDate;

        public Account(int i, string t)
        {
            if (i > 0) id = i;
            else Console.WriteLine("Id must be > 0");

            if (!string.IsNullOrWhiteSpace(t)) type = t;
            else Console.WriteLine("Type cannot be empty");

            openDate = DateTime.Now;
        }

        public Account(Customer c)
        {
            if (c != null) customer = c;
            else Console.WriteLine("Customer cannot be null");
            openDate = DateTime.Now;
        }

        public void Deposit(double amt)
        {
            if (amt > 0) balance += amt;
            else Console.WriteLine("Deposit must be > 0");
        }

        public void Withdraw(double amt)
        {
            if (amt <= 0) Console.WriteLine("Withdraw must be > 0");
            else if (amt > balance) Console.WriteLine("Insufficient funds");
            else balance -= amt;
        }

        public void Close()
        {
            if (balance == 0) Console.WriteLine("Account closed");
            else Console.WriteLine("Balance must be zero to close");
        }

        public void AssignCustomer(Customer c)
        {
            if (c != null) customer = c;
            else Console.WriteLine("Customer cannot be null");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Account Id: " + id + ", Type: " + type + ", Balance: " + balance + ", Opened: " + openDate);
            if (customer != null) customer.DisplayInfo();
        }
    }
}

