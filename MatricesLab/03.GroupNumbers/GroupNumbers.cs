using System;
using System.Linq;
using System.Net.Sockets;

namespace _03.GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var matrix = new int[3][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = numbers.Where(n => Math.Abs(n) % 3 == i).ToArray();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }
        }
    }
}
