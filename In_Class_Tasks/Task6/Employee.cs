using System;

namespace Task6
{
    public class Employee
    {
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Hours { get; set; }

        public Employee()
        {
            Name = "New Hire";
            Rate = 0;
            Hours = 0;
        }

        public Employee(string name)
        {
            Name = name;
            Rate = 45;
            Hours = 40;
        }

        public Employee(string name, double rate, int hours)
        {
            Name = name;
            Rate = rate;
            Hours = hours;
        }

        public void DisplaySummary()
        {
            double salary = Rate * Hours * 52;
            Console.WriteLine($"{Name} earns ${salary}");
        }
    }
}

