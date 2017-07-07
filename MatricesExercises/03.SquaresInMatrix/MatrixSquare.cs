using System;
using System.Linq;

namespace _03.SquaresInMatrix
{
    public class MatrixSquare
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = numbers[0];
            var cols = numbers[1];
            var matrix = new string[rows][];
            var counter = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().ToArray();
            }

            for (int i = 0; i < matrix.Length-1; i++)
            {
                for (int j = 0; j < matrix[i].Length-1; j++)
                {
                    if (matrix[i][j].Equals(matrix[i][j + 1]) && matrix[i][j].Equals(matrix[i+1][j])
                        && matrix[i][j].Equals(matrix[i+1][j + 1]))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
