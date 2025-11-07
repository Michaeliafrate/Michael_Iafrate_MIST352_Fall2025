using System;

namespace Task6
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car()
        {
            Make = "Sports Car";
            Model = "(AWD)";
            Year = DateTime.Now.Year;
        }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Year = DateTime.Now.Year;
        }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Year} {Make} {Model}");
        }
    }
}

