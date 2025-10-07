using System;

class Task4
{
    static void Main(string[] args)
    {
        // Define an array of at least 6 integers
        int[] intArray = { 10, 5, 15, 20, 8, 12 };

        // Call PrintArray
        PrintArray(intArray);

        // Call FindAverage and display result
        double dblAverage = FindAverage(intArray);
        Console.WriteLine($"The average is: {dblAverage:F2}");

        // Ask user for a number to search
        Console.Write("Enter a number to search: ");
        int intTarget = Convert.ToInt32(Console.ReadLine());

        // Call SearchNumber
        SearchNumber(intArray, intTarget);

        // Bonus: FindMax
        int intMax = FindMax(intArray);
        Console.WriteLine($"The largest number in the array is: {intMax}");
    }

    /// <summary>
    /// Prints all elements of the array.
    /// </summary>
    static void PrintArray(int[] intArray)
    {
        Console.Write("Array elements: ");
        foreach (int intValue in intArray)
        {
            Console.Write(intValue + " ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Calculates and returns the average of the array.
    /// </summary>
    static double FindAverage(int[] intArray)
    {
        int intSum = 0;
        foreach (int intValue in intArray)
        {
            intSum += intValue;
        }
        return (double)intSum / intArray.Length;
    }

    /// <summary>
    /// Searches for a target number in the array and prints result.
    /// </summary>
    static void SearchNumber(int[] intArray, int intTarget)
    {
        bool blnFound = false;
        foreach (int intValue in intArray)
        {
            if (intValue == intTarget)
            {
                blnFound = true;
                break;
            }
        }

        if (blnFound)
            Console.WriteLine($"{intTarget} was found in the array!");
        else
            Console.WriteLine($"{intTarget} was NOT found in the array.");
    }

    /// <summary>
    /// Finds and returns the largest number in the array.
    /// </summary>
    static int FindMax(int[] intArray)
    {
        int intMax = intArray[0];
        foreach (int intValue in intArray)
        {
            if (intValue > intMax)
                intMax = intValue;
        }
        return intMax;
    }
}
