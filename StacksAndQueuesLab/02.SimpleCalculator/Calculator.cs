using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    public class Calculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Reverse();
            var stack = new Stack<string>();

            foreach (var word in input)
            {
                stack.Push(word);
            }

            var stackCount = stack.Count-1;

            var number = int.Parse(stack.Pop());

            for (int i = 0; i <stackCount/2; i++)
            {
                var result = 0;

                var operation = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if (operation=="+")
                {
                    result = number + secondNumber;
                }
                else
                {
                    result = number - secondNumber;
                }

                number = result;
            }

            Console.WriteLine(number);
        }
    }
}
