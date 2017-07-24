using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    public class PredicateForNames
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split()
                .ToList();

            Action<List<string>, int> printNames =
                (x, l) => x.Where(y => y.Length <= l).
                ToList().
                ForEach(k => Console.WriteLine(k));

            printNames(names, length);
        }
    }
}
