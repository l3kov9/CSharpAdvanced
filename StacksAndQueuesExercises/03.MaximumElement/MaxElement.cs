using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    public class MaxElement
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var operation = Console.ReadLine().Split().Select(int.Parse).ToList();
                var code = operation[0];

                if (code==1)
                {
                    stack.Push(operation[1]);
                }
                else if (code == 2)
                {
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine(stack.Max());
                }
            }
        }
    }
}
