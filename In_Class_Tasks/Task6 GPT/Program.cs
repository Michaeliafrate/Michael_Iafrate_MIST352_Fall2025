/* Prompt used for Task6_GPT: "Generate C# classes for Car, Employee, 
 and Account with constructors, validation, 
 encapsulation, and formatted display methods. 
 Add input validation, default fallbacks, and extra helper methods. 
 Then create three objects of each in Main and display their info." 
*/


namespace Task6_GPT
{
    using System;

    public class Car
    {
        private string make;
        private string model;
        private int year;

        public string Make
        {
            get => make;
            set => make = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public string Model
        {
            get => model;
            set => model = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public int Year
        {
            get => year;
            set => year = (value >= 1886 && value <= DateTime.Now.Year) ? value : DateTime.Now.Year;
        }

        public Car() : this("Generic", "Car", DateTime.Now.Year) { }

        public Car(string make, string model) : this(make, model, DateTime.Now.Year) { }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[Car] {Year} {Make} {Model}");
        }
    }

    public class Employee
    {
        private string name;
        private double hourlyRate;
        private int hoursPerWeek;

        public string Name
        {
            get => name;
            set => name = string.IsNullOrWhiteSpace(value) ? "Unnamed Employee" : value;
        }

        public double HourlyRate
        {
            get => hourlyRate;
            set => hourlyRate = (value > 0) ? value : 15.0;
        }

        public int HoursPerWeek
        {
            get => hoursPerWeek;
            set => hoursPerWeek = (value > 0 && value <= 60) ? value : 40;
        }

        public Employee() : this("New Hire", 15.0, 40) { }

        public Employee(string name) : this(name, 15.0, 40) { }

        public Employee(string name, double rate, int hours)
        {
            Name = name;
            HourlyRate = rate;
            HoursPerWeek = hours;
        }

        public double AnnualSalary() => HourlyRate * HoursPerWeek * 52;

        public void DisplaySummary()
        {
            Console.WriteLine($"[Employee] {Name} | Rate: ${HourlyRate:F2}/hr | Hours: {HoursPerWeek} | Annual: ${AnnualSalary():F2}");
        }
    }

    public class Account
    {
        private int accountNumber;
        private string owner;
        private double balance;

        public int AccountNumber => accountNumber;
        public string Owner => owner;
        public double Balance => balance;

        public Account() : this(0, "Unknown", 0.0) { }

        public Account(int number, string owner) : this(number, owner, 0.0) { }

        public Account(int number, string owner, double balance)
        {
            accountNumber = number > 0 ? number : 0;
            this.owner = string.IsNullOrWhiteSpace(owner) ? "Unknown" : owner;
            this.balance = balance >= 0 ? balance : 0.0;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"[Account] Deposit successful: +${amount:F2}");
            }
            else
            {
                Console.WriteLine("[Account] Invalid deposit amount.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"[Account] Withdrawal successful: -${amount:F2}");
            }
            else
            {
                Console.WriteLine("[Account] Withdrawal failed: insufficient funds or invalid amount.");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[Account] #{AccountNumber} | Owner: {Owner} | Balance: ${Balance:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car();
            Car c2 = new Car("Toyota", "Camry");
            Car c3 = new Car("Ford", "Mustang", 1969);

            c1.DisplayInfo();
            c2.DisplayInfo();
            c3.DisplayInfo();

            Console.WriteLine();

            Employee e1 = new Employee();
            Employee e2 = new Employee("Alice");
            Employee e3 = new Employee("Bob", 25.0, 35);

            e1.DisplaySummary();
            e2.DisplaySummary();
            e3.DisplaySummary();

            Console.WriteLine();

            Account a1 = new Account();
            Account a2 = new Account(1001, "Charlie");
            Account a3 = new Account(1002, "Dana", 500.0);

            a1.DisplayInfo();
            a2.Deposit(200);
            a2.DisplayInfo();
            a3.Withdraw(100);
            a3.DisplayInfo();
        }
    }
}

