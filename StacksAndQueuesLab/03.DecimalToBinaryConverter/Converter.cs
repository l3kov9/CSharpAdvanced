using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DecimalToBinaryConverter
{
    public class Converter
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (number>0)
            {
                stack.Push(number%2);
                number /= 2;
            }

            Console.WriteLine(string.Join("",stack));
        }
    }
}
