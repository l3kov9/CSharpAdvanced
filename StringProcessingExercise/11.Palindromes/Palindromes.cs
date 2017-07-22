using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[]{' ',',','?','.','!'},StringSplitOptions.RemoveEmptyEntries);
            var palindromes=new SortedSet<string>();

            foreach (var word in input)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ",palindromes)}]");
        }

        private static bool IsPalindrome(string word)
        {
            var currentWord = word;
            var reversedWordArray = word.ToCharArray().Reverse();
            var reversedWord = string.Join("", reversedWordArray);
            if (currentWord.Equals(reversedWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
