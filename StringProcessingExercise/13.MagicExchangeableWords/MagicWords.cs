using System;
using System.Collections.Generic;

namespace _13.MagicExchangeableWords
{
    public class MagicWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();
            var firstWord = words[0];
            var secondWord = words[1];
            var dictionary=new Dictionary<char,HashSet<char>>();

            var maxLength = Math.Max(firstWord.Length, secondWord.Length);
            firstWord = firstWord.PadRight(maxLength, ' ');

            for (int i = 0; i < maxLength; i++)
            {
                if (!dictionary.ContainsKey(firstWord[i]))
                {
                    dictionary[firstWord[i]]=new HashSet<char>();
                }
                dictionary[firstWord[i]].Add(secondWord[i]);

                if (dictionary[firstWord[i]].Count > 1)
                {
                    Console.WriteLine("false");
                    return;
                }
            }

            Console.WriteLine("true");
        }
    }
}
