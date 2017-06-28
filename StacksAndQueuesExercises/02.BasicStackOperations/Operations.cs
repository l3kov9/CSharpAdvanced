using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    public class Operations
    {
        public static void Main()
        {
            var operations = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            var checkingElement = operations.Pop();
            var popCount = operations.Pop();
            var pushCout = operations.Pop();

            var queue=new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var stack=new Stack<int>(queue.Take(pushCout));

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(checkingElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
