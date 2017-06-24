using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack=new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('('))
                {
                    stack.Push(i);
                }
                else if (input[i].Equals(')'))
                {
                    var startIndex = stack.Pop();
                    var content = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(content);
                }
            }

        }
    }
}
