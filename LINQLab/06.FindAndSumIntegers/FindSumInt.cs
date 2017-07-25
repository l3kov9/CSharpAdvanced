using System;
using System.Linq;

namespace _06.FindAndSumIntegers
{
    public class FindSumInt
    {
        public static void Main()
        {
            var result = 0;

            var totalSum = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.TryParse(x, out result))
                .Select(int.Parse)
                .ToList();

            if (totalSum.Count > 0)
            {
                Console.WriteLine(totalSum.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
