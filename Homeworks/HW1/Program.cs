/******************************************************
Author: Michael Iafrate
Class: MIST352-Fall2025
HW #1
Description: This program collects details for four products 
             from the user, calculates each product's total 
             price, and displays all data in a formatted table.
******************************************************/

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Arrays to store product data
        string[] productNames = new string[4];
        int[] serialNumbers = new int[4];
        decimal[] prices = new decimal[4];
        int[] quantities = new int[4];
        string[] categories = new string[4];

        // TextInfo for capitalization
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        // Header
        Console.WriteLine("MIS352-Fall2025");
        Console.WriteLine("HW #1");
        Console.WriteLine("This program collects product details, calculates total prices, and displays them in a table.\n");

        Console.WriteLine("=== Product Entry Program ===");

        // Loop to collect data for 4 products
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"\n--- Enter details for Product #{i + 1} ---");

            // Product name
            Console.Write("Enter product name: ");
            productNames[i] = textInfo.ToTitleCase(Console.ReadLine().Trim().ToLower());

            // Serial number (integer only)
            while (true)
            {
                Console.Write("Enter product serial number (numeric only): ");
                if (int.TryParse(Console.ReadLine(), out int serial))
                {
                    serialNumbers[i] = serial;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }

            // Price (decimal)
            while (true)
            {
                Console.Write("Enter product price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    prices[i] = price;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid price.");
            }

            // Quantity (integer only)
            while (true)
            {
                Console.Write("Enter product quantity: ");
                if (int.TryParse(Console.ReadLine(), out int qty))
                {
                    quantities[i] = qty;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }

            // Category
            Console.Write("Enter product category: ");
            categories[i] = textInfo.ToTitleCase(Console.ReadLine().Trim().ToLower());
        }

        // Table header
        Console.WriteLine("\n{0,-15} {1,-15} {2,-10} {3,-10} {4,-15} {5,-12}",
            "Name", "Serial #", "Price", "Quantity", "Category", "Total Price");
        Console.WriteLine(new string('-', 80));

        // Display all products with calculated total price
        for (int i = 0; i < 4; i++)
        {
            decimal totalPrice = prices[i] * quantities[i];
            Console.WriteLine("{0,-15} {1,-15} {2,-10:C} {3,-10} {4,-15} {5,-12:C}",
                productNames[i], serialNumbers[i], prices[i], quantities[i], categories[i], totalPrice);
        }
    }
}



