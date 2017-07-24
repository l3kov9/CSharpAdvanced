using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    public class EvenOddsFinder
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var startIndex = range[0];
            var endIndex = range[1];
            var command = Console.ReadLine();

            var numbers = new List<int>();

            Func<int,List<int>, List<int>> addNumber = (x,y) =>
            {

                if (command == "even" && x % 2 == 0)
                {
                    y.Add(x);
                }
                else if (command == "odd" && x % 2 == 1)
                {
                    y.Add(x);
                }
                
                return y;
            };


            for (int i = startIndex; i <= endIndex; i++)
            {
                addNumber(i,numbers);
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
