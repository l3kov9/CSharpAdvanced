using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isLargerLength = (x, y) =>
            {
                var sum = 0;
                foreach (var letter in x)
                {
                    sum += (int) letter;
                }

                if (sum >= y)
                {
                    return true;
                }
                return false;
            };

            Func<List<string>, Func<string, int, bool>,int, string> firstMatchWord = (list, funct,count) =>
            {
                foreach (var word in list)
                {
                    if (funct(word, count))
                    {
                        return word;
                    }
                }
                return "No match";
            };

            var result = firstMatchWord(names, isLargerLength,length);

            Console.WriteLine(result);
        }
    }
}
