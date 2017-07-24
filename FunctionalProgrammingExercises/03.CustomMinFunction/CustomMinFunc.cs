using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    public class CustomMinFunc
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>,int> minNumber = x => x.Min();

            Console.WriteLine(minNumber(numbers));
        }
    }
}
