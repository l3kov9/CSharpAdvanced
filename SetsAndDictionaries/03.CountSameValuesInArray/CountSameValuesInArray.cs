using System;
using System.Collections.Generic;

namespace _03.CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var dictionary=new SortedDictionary<decimal,int>();

            foreach (var num in input)
            {
                var number = decimal.Parse(num.Replace(',', '.'));
                AddToDictionary(dictionary, number);
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }

        private static void AddToDictionary(SortedDictionary<decimal, int> dictionary, decimal num)
        {
            if (!dictionary.ContainsKey(num))
            {
                dictionary[num] = 0;
            }

            dictionary[num]++;
        }
    }
}
