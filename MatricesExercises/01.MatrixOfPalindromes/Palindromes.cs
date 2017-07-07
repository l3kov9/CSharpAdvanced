using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = numbers[0];
            var cols = numbers[1];

            var alphabet= "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrix=new string[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                    matrix[i] = CheckForPalindrome(i, alphabet,cols);
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }

        }


        private static string[] CheckForPalindrome(int i, char[] alphabet,int cols)
        {
            var result = new List<string>();

            for (int j = i; j < alphabet.Length; j++)
            {
                for (int k = i; k < alphabet.Length; k++)
                {
                    for (int l = i; l < alphabet.Length; l++)
                    {
                        var text = alphabet[j].ToString() + alphabet[k].ToString() + alphabet[l].ToString();
                        if (isPalindrome(text))
                        {
                            result.Add(text);
                        }

                        if (result.Count > cols-1)
                        {
                            return result.ToArray();
                        }
                    }
                }
            }

            return result.ToArray();
        }

        private static bool isPalindrome(string text)
        {
            if (text[0].Equals(text[2]))
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
