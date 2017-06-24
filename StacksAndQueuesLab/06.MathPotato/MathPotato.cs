using System;
using System.Collections.Generic;

namespace _06.MathPotato
{
    public class MathPotato
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var queue = new Queue<string>(names);
            var n = int.Parse(Console.ReadLine());
            var cycle = 1;

            while (queue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine(IsPrime(cycle) ? $"Prime {queue.Peek()}" : $"Removed {queue.Dequeue()}");

                cycle++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int number)
        {

            if (number == 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }

            for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
