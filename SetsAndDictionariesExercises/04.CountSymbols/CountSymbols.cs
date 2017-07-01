using System;
using System.Collections.Generic;

namespace _04.CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var symbols=new SortedDictionary<char,int>();

            for (int i = 0; i < input.Length; i++)
            {
                AddToDictionary(symbols, input[i]);
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }

        private static void AddToDictionary(SortedDictionary<char, int> symbols, char letter)
        {
            if (!symbols.ContainsKey(letter))
            {
                symbols[letter] = 0;
            }

            symbols[letter]++;
        }
    }
}
