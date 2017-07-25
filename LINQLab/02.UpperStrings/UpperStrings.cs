using System;
using System.Linq;

namespace _02.UpperStrings
{
    public class UpperStrings
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToUpper())
                .ToList()
                .ForEach(x => Console.Write(x + " "));
        }
    }
}
