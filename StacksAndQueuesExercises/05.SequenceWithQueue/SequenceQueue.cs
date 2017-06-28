using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    public class SequenceQueue
    {
        public static void Main()
        {
            var firstNum = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(firstNum);
            var nextNumber = firstNum;

            for (int i =1 ; i <= 16; i++)
            {
                queue.Enqueue(firstNum+1);
                queue.Enqueue(2*firstNum+1);
                queue.Enqueue(firstNum+2);

                firstNum += 1;
            }

            Console.WriteLine(string.Join(" ",queue));
        }
    }
}
