using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> calcSumArray = n => n.Sum();
            Func<List<int>, int> calcCountArray = n => n.Count;

            Console.WriteLine(calcCountArray(numbers));
            Console.WriteLine(calcSumArray(numbers));
        }
    }
}
