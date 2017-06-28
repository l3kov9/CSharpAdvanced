using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    public class Reverse
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var stack=new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ",stack));
            
        }
    }
}
