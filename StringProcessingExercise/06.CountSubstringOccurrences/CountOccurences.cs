using System;

namespace _06.CountSubstringOccurrences
{
    public class CountOccurences
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var searchingStr = Console.ReadLine();
            var counter = 0;

            while (input.IndexOf(searchingStr,StringComparison.OrdinalIgnoreCase)!=-1)
            {
                counter++;

                input = input.Substring(input.IndexOf(searchingStr, StringComparison.OrdinalIgnoreCase) + 1);
            }

            Console.WriteLine(counter);
        }
    }
}
