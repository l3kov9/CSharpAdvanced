using System;
using System.Linq;

namespace _04.ConvertFrombase10TobaseN
{
    public class ConvertingBases
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var baseNum = nums[0];
            var number = nums[1];

            Console.WriteLine($"{number}");
        }
    }
}
