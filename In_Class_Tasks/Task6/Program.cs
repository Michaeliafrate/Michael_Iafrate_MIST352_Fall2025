using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cars
            Car c1 = new Car();
            Car c2 = new Car("Tesla", "Model Y");
            Car c3 = new Car("BMW", "M5", 2025);

            Console.WriteLine("===============================================================");

            c1.DisplayInfo();
            c2.DisplayInfo();
            c3.DisplayInfo();

            Console.WriteLine("===============================================================");

            // Employees
            Employee e1 = new Employee();
            Employee e2 = new Employee("Mike");
            Employee e3 = new Employee("Sarah", 20, 35);


            e1.DisplaySummary();
            e2.DisplaySummary();
            e3.DisplaySummary();

            Console.WriteLine("===============================================================");

            // Accounts
            Account account1 = new Account();
            Account account2 = new Account(1001, "Sarah");
            Account account3 = new Account(1002, "Mike", 29000);

            account1.DisplayInfo();
            account2.Deposit(4000);
            account2.DisplayInfo();
            account3.Withdraw(1200);
            account3.DisplayInfo();

            Console.WriteLine("===============================================================");

        }
    }
}
