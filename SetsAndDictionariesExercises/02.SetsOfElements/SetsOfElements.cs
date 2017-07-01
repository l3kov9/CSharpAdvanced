using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            var setLength = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var firstSet=new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < setLength[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setLength[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ",firstSet));
        }
    }
}
