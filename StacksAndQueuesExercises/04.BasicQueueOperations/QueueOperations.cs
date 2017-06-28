using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class QueueOperations
    {
        public static void Main()
        {
            var operations = Console.ReadLine().Split().Select(int.Parse);
            var operationsQueue = new Queue<int>(operations);
            var totalElements = operationsQueue.Dequeue();
            var deduqueElements = operationsQueue.Dequeue();
            var checkingElement = operationsQueue.Dequeue();

            var queue=new Queue<int>(Console.ReadLine().Split().Select(int.Parse).Take(totalElements));
            for (int i = 0; i < deduqueElements; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(checkingElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
