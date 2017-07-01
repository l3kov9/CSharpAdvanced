using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var perTable=new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    perTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",perTable));
        }
    }
}
