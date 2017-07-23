using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    public class CountingWords
    {
        public static void Main()
        {
            Func<string, bool> isStartingUpperCase = n => n[0] == n.ToUpper()[0];

            Console.ReadLine()
                .Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
                .Where(isStartingUpperCase)
                .ToList()
                .ForEach(x=>Console.WriteLine(x));
        }
    }
}
