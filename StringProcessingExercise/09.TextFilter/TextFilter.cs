using System;

namespace _09.TextFilter
{
    public class TextFilter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var input = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                input = input.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(input);
        }
    }
}
