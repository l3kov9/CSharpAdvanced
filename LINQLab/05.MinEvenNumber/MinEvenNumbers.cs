using System;
using System.Linq;

namespace _05.MinEvenNumber
{
    public class MinEvenNumbers
    {
        public static void Main()
        {
            var minEvenNumber = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x=>x)
                .FirstOrDefault();


            if (minEvenNumber == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{minEvenNumber:f2}");
            }
        }
    }
}
