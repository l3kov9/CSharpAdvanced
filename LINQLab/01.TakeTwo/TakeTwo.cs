using System;
using System.Linq;

namespace _01.TakeTwo
{
    public class TakeTwo
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .Where(x => x >= 10 && x <= 20)
                .Take(2)
                .ToList()
                .ForEach(x=>Console.Write(x+" "));
        }
    }
}
