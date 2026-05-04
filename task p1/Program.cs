using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] data =
        {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

        Array.Sort(data);

        int n = data.Length;

         
        double mean = data.Average();

        
        double median;
        if (n % 2 == 0)
            median = (data[n / 2 - 1] + data[n / 2]) / 2.0;
        else
            median = data[n / 2];

        
        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        
        double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();

        
        double stdDev = Math.Sqrt(variance);


        double Percentile(int[] arr, double p)
        {
            double index = (p / 100.0) * (arr.Length - 1);
            int lower = (int)Math.Floor(index);
            int upper = (int)Math.Ceiling(index);

            if (lower == upper)
                return arr[lower];

            return arr[lower] + (arr[upper] - arr[lower]) * (index - lower);
        }

        double p20 = Percentile(data, 20);
        double p50 = Percentile(data, 50);

         
        double q1 = Percentile(data, 25);
        double q2 = Percentile(data, 50);
        double q3 = Percentile(data, 75);

        
        int range = data.Max() - data.Min();

        
        double iqr = q3 - q1;

        
        int summation = data.Sum();

        
        Console.WriteLine("Sorted Data:");
        foreach (int num in data)
            Console.Write(num + " ");

        Console.WriteLine("\n\nResults:");
        Console.WriteLine($"Mean = {mean}");
        Console.WriteLine($"Mode = {mode}");
        Console.WriteLine($"Median = {median}");
        Console.WriteLine($"Variance = {variance}");
        Console.WriteLine($"P20 = {p20}");
        Console.WriteLine($"P50 = {p50}");
        Console.WriteLine($"First Quartile (Q1) = {q1}");
        Console.WriteLine($"Second Quartile (Q2) = {q2}");
        Console.WriteLine($"Third Quartile (Q3) = {q3}");
        Console.WriteLine($"Range = {range}");
        Console.WriteLine($"Interquartile Range = {iqr}");
        Console.WriteLine($"Standard Deviation = {stdDev}");
        Console.WriteLine($"Summation = {summation}");
    }
}