using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> printNames = x => x.ForEach(y => Console.WriteLine(y));
            Action<List<string>> printNamesAddingPrefix = x => x.ForEach(y => Console.WriteLine($"Sir {y}"));

            PrintAllNames(names, printNames);
        }

        private static void PrintAllNames(List<string> names, Action<List<string>> printNames)
        {
            printNames(names);
        }
    }
}
