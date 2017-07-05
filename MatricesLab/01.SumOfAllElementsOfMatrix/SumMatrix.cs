using System;
using System.Linq;

namespace _01.SumOfAllElementsOfMatrix
{
    public class SumMatrix
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new []{' ',','},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = numbers[0];
            var cols = numbers[1];
            var sum = 0;
            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sum += matrix[i].Sum();
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
