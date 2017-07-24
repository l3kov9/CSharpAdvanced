using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    public class Arithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();
            Func<List<int>,List<int>> addOne = x => x.Select(y => y + 1).ToList();
            Func<List<int>, List<int>> multiplyNums = x => x.Select(y => y * 2).ToList();
            Func<List<int>, List<int>> subtractOne = x => x.Select(y => y - 1).ToList();

            while (command!="end")
            {
                if (command.Equals("add"))
                {
                    numbers=addOne(numbers);
                }
                else if (command.Equals("multiply"))
                {
                    numbers=multiplyNums(numbers);
                }
                else if (command.Equals("subtract"))
                {
                    numbers=subtractOne(numbers);
                }
                else if (command.Equals("print"))
                {
                    Console.WriteLine(string.Join(" ",numbers));
                }


                command = Console.ReadLine();
            }
        }
    }
}
