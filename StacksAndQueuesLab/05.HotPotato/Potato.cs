using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.HotPotato
{
    public class Potato
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var queue=new Queue<string>(names);
            var n = int.Parse(Console.ReadLine());

            while (queue.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                   queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
