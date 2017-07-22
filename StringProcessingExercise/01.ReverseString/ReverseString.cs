using System;
using System.Text;

namespace _01.ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var reversedText = ReverseText(text);

            Console.WriteLine(reversedText);
        }

        private static string ReverseText(string text)
        {
            var sb=new StringBuilder();

            for (int i = text.Length-1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}
