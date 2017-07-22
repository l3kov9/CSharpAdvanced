using System;
using System.Text;

namespace _10.UnicodeCharacters
{
    public class UnicodeChar
    {
        public static void Main()
        {
            var sb=new StringBuilder();
            var input = Console.ReadLine();

            foreach (var letter in input)
            {
                sb.Append(@"\u");
                sb.Append(string.Format($"{(int)letter:X4}"));
            }

            Console.WriteLine(sb);
        }
    }
}
