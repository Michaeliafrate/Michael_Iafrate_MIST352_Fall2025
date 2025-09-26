using System;

namespace In_Class_Tasks
{
    class Task3
    {
        static void Main(string[] args)
        {
            const double TAX_RATE = 0.06;   // 6% sales tax
            const double BULK_DISCOUNT = 0.05; // 5% discount

            Console.Write("How many items are in this order? ");
            int itemCount;
            if (!int.TryParse(Console.ReadLine(), out itemCount) || itemCount <= 0)
            {
                Console.WriteLine("Invalid number of items. Exiting...");
                return;
            }

            // Arrays
            string[] names = new string[itemCount];
            double[] prices = new double[itemCount];
            int[] qtys = new int[itemCount];
            int[] stocks = new int[itemCount];
            double[] lineTotals = new double[itemCount];
            double[] lineDiscounts = new double[itemCount];
            bool[] reorder = new bool[itemCount];

            // Input loop
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"\nItem #{i + 1}");

                // Product name
                Console.Write("Enter product name: ");
                names[i] = Console.ReadLine();

                // Price
                Console.Write("Enter unit price (e.g., 12.50): ");
                double price;
                if (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                {
                    Console.WriteLine("[Warn] Invalid price. Defaulting to 0");
                    price = 0;
                }
                prices[i] = price;

                // Quantity
                Console.Write("Enter quantity (integer): ");
                int qty;
                if (!int.TryParse(Console.ReadLine(), out qty) || qty < 0)
                {
                    Console.WriteLine("[Warn] Invalid quantity. Defaulting to 0");
                    qty = 0;
                }
                qtys[i] = qty;

                // Stock
                Console.Write("Enter stock on hand (integer): ");
                int stock;
                if (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
                {
                    Console.WriteLine("[Warn] Invalid stock. Defaulting to 0");
                    stock = 0;
                }
                stocks[i] = stock;

                // Business rules
                double gross = prices[i] * qtys[i];

                if (qtys[i] >= 10)
                    lineDiscounts[i] = gross * BULK_DISCOUNT;
                else
                    lineDiscounts[i] = 0;

                lineTotals[i] = gross - lineDiscounts[i];

                int postSaleStock = stocks[i] - qtys[i];
                reorder[i] = postSaleStock < 5;
            }

            // Totals
            double subtotal = 0;
            for (int i = 0; i < itemCount; i++)
                subtotal += lineTotals[i];

            double tax = subtotal * TAX_RATE;
            double grandTotal = subtotal + tax;

            // Output
            Console.WriteLine("\n=== Order Summary ===");
            Console.WriteLine($"{"Name",-12} {"Price",8} {"Qty",5} {"Gross",10} {"Disc",10} {"Line Total",12} {"Reorder",8}");
            Console.WriteLine(new string('-', 70));

            for (int i = 0; i < itemCount; i++)
            {
                double gross = prices[i] * qtys[i];
                Console.WriteLine($"{names[i],-12} {prices[i],8:F2} {qtys[i],5} {gross,10:F2} {lineDiscounts[i],10:F2} {lineTotals[i],12:F2} {(reorder[i] ? "YES" : "NO"),8}");
            }

            Console.WriteLine($"\nSubtotal: {subtotal:F2}");
            Console.WriteLine($"Tax (6%): {tax:F2}");
            Console.WriteLine($"GRAND TOTAL: {grandTotal:F2}");
        }
    }
}
