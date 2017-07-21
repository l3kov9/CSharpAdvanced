using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _04.SpecialWords
{
    public class SpecialWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();
            var specialWords=new Dictionary<string,int>();

            foreach (var word in words)
            {
                specialWords[word] = 0;
            }

            var text = Console.ReadLine().Split("( ) [ ] < > , - ! ? (‘ ’)".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in text)
            {
                if (specialWords.ContainsKey(word))
                {
                    specialWords[word]++;
                }
            }

            foreach (var kvp in specialWords)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
