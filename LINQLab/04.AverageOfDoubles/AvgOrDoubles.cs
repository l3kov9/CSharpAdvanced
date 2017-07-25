using System;
using System.Linq;

namespace _04.AverageOfDoubles
{
    public class AvgOrDoubles
    {
        public static void Main()
        {
            Console.WriteLine($"{Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Average():f2}");
        }
    }
}
