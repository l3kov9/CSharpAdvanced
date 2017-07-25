using System;
using System.Linq;
using System.Linq.Expressions;

namespace _07.BoundedNumbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var border = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            var lowerBound = border[0];
            var upperBound = border[1];

            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x >= lowerBound && x <= upperBound)
                .ToList()
                .ForEach(x=>Console.Write(x+" "));

        }
    }
}
