using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    public class SquareSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new []{' ',','},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = numbers[0];
            var cols = numbers[1];
            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var maxSum = int.MinValue;
            var maxMatrix = new int[2,2];

            for (int i = 0; i < matrix.Length-1; i++)
            {
                for (int j = 0; j < matrix[i].Length-1; j++)
                {
                    var squareSum = matrix[i][j] + matrix[i][j + 1] + matrix[i + 1][j] + matrix[i + 1][j + 1];
                    if (maxSum < squareSum)
                    {
                        maxSum = squareSum;
                        maxMatrix[0, 0] = matrix[i][j];
                        maxMatrix[0, 1] = matrix[i][j + 1];
                        maxMatrix[1, 0] = matrix[i + 1][j];
                        maxMatrix[1, 1] = matrix[i + 1][j + 1];
                    }
                }
            }

            for (int i = 0; i < maxMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxMatrix.GetLength(1); j++)
                {
                    Console.Write(maxMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
