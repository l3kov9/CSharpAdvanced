using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    public class KnightsHonor
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printKnightsNames = x => x.ForEach(y => Console.WriteLine($"Sir {y}"));

            printKnightsNames(names);
        }
    }
}
