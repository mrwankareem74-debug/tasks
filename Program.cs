using System;
using System.Linq;

class Program
{
    static double Percentile(int[] arr, double p)
    {
        double index = (p / 100.0) * (arr.Length - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);

        if (lower == upper)
            return arr[lower];

        return arr[lower] + (arr[upper] - arr[lower]) * (index - lower);
    }

    static void Main()
    {
        int[] data =
        {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

        Array.Sort(data);

        double q1 = Percentile(data, 25);
        double q3 = Percentile(data, 75);
        double iqr = q3 - q1;

        double lowerBound = q1 - (1.5 * iqr);
        double upperBound = q3 + (1.5 * iqr);

        Console.WriteLine($"Q1 = {q1}");
        Console.WriteLine($"Q3 = {q3}");
        Console.WriteLine($"IQR = {iqr}");
        Console.WriteLine($"Lower Bound = {lowerBound}");
        Console.WriteLine($"Upper Bound = {upperBound}\n");

        Console.WriteLine("Checking Outliers:\n");

        foreach (int num in data)
        {
            if (num < lowerBound || num > upperBound)
                Console.WriteLine($"{num} is an Outlier");
            else
                Console.WriteLine($"{num} is NOT an Outlier");
        }
    }
}