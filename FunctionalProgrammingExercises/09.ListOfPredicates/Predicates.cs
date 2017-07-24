using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    public class Predicates
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var numbersToDivide = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;
            var result=new List<int>();

            for (int i = 1; i <= number; i++)
            {
                var divide = true;

                foreach (var num in numbersToDivide)
                {
                    if (!isDivisible(i, num))
                    {
                        divide = false;
                        break;
                    }
                }
                if (divide)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
