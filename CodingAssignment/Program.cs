using CodingAssignment.Definitions;
using CodingAssignment.Implementations;
using System;
using System.Collections.Generic;

namespace CodingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { 1, 3, 5, 7, 9, 10, 11, 12 };
            //var finder = new OptimisedIntervalFinder();
            var finder = new SimpleIntervalFinder(); //Alternative implementation, which supports unordered input

            finder.Add(input);

            var r1 = finder.GetResult(2);
            var r2 = finder.GetResult(5);
            var r3 = finder.GetResult(10);

            PrintResult(input, 2, r1);
            PrintResult(input, 5, r2);
            PrintResult(input, 10, r3);
        }

        static void PrintResult(int[] input, int interval, List<IntervalResult> outcome)
        {
            Console.WriteLine("************************************");
            Console.WriteLine($" Input Array: {String.Join(",", input)}, Interval:{interval}");
            foreach (var item in outcome)
            {
                Console.WriteLine($" Numbers : {String.Join(",", item.Numbers)}, Frequency: {item.Frequency}");
            }
        }
    }
}
