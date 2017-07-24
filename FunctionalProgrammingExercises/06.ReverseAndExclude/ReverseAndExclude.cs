using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stack=new Stack();
            foreach (var num in numbers)
            {
                stack.Push(num);
            }

            var n = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;
            var result=new List<int>();

            foreach (var num in stack)
            {
                if (!isDivisible(int.Parse(num.ToString()),n))
                {
                    result.Add(int.Parse(num.ToString()));
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
